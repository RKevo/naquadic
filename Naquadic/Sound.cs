using System.Runtime.InteropServices;
using Naquadic.Common.Enums;
using Naquadic.Common.Structs;
using Naquadic.Logging;
using static Naquadic.Common.Utils;

namespace Naquadic.Thin;

#pragma warning disable IDE1006 // Naming Styles

public interface IDataSourceProvider
{
    internal unsafe void* __unsafeRef();
}

public class Sound : IDisposable, ISoundNode
{
    private ma_sound _sound;
    private Engine _engine;
    private unsafe ma_sound* _ref;
    private bool _disposed;

    /// <summary>
    /// Initialize by file path.
    /// </summary>
    /// <param name="engine"></param>
    /// <param name="filePath"></param>
    /// <param name="flags"></param>
    /// <param name="group"></param>
    /// <param name="fence"></param>
    public unsafe Sound(Engine engine, string filePath, uint flags, SoundGroup group, Fence fence)
    {
        ma_result result;
        _engine = engine;
        fixed (ma_sound* s = &_sound)
        {
            result = funcs.ma_sound_init_from_file(
                engine.__unsafeRef(),
                LendString(filePath),
                flags,
                group.__unsafeRef(),
                &fence,
                s
            );
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Sound initialiation error: {result}");
        }
        _ref = __unsafeRef();
    }

    /// <summary>
    /// Initialize with a data source.
    /// </summary>
    /// <param name="engine"></param>
    /// <param name="src"></param>
    /// <param name="flags"></param>
    /// <param name="group"></param>
    /// <param name="fence"></param>
    public unsafe Sound(
        Engine engine,
        IDataSourceProvider src,
        uint flags,
        SoundGroup group,
        Fence fence
    )
    {
        ma_result result;
        _engine = engine;
        fixed (ma_sound* s = &_sound)
        {
            result = funcs.ma_sound_init_from_data_source(
                engine.__unsafeRef(),
                src.__unsafeRef(),
                flags,
                group.__unsafeRef(),
                s
            );
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Sound initialiation error: {result}");
        }
        _ref = __unsafeRef();
    }

    public unsafe Sound(Engine engine, SoundConfig config)
    {
        ma_result result;
        _engine = engine;
        fixed (ma_sound* s = &_sound)
        {
            result = funcs.ma_sound_init_ex(engine.__unsafeRef(), config.__unsafeRef(), s);
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Sound initialiation error: {result}");
        }
        _ref = __unsafeRef();
    }

    // I don't think I will support `ma_sound_init_from_file_w`

    /// <summary>
    /// Initialize by copy.
    /// </summary>
    /// <param name="engine"></param>
    /// <param name="existing"></param>
    /// <param name="flags"></param>
    /// <param name="group"></param>
    public unsafe Sound(Engine engine, Sound existing, uint flags, SoundGroup group)
    {
        ma_result result;
        _engine = engine;
        fixed (ma_sound* s = &_sound)
        {
            result = funcs.ma_sound_init_copy(
                engine.__unsafeRef(),
                existing.__unsafeRef(),
                flags,
                group.__unsafeRef(),
                s
            );
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Sound initialiation error: {result}");
        }
        _ref = __unsafeRef();
    }

    internal unsafe ma_sound* __unsafeRef()
    {
        fixed (ma_sound* c = &_sound)
        {
            return c;
        }
    }

    public unsafe uint IsLooping
    {
        get => funcs.ma_sound_is_looping(_ref);
        set => funcs.ma_sound_set_looping(_ref, value);
    }

    public unsafe uint Ended => funcs.ma_sound_at_end(_ref);

    /// <summary>
    ///
    /// </summary>
    /// <param name="frameIndex">Time in PCM frames</param>
    public unsafe void Seek(ulong frameIndex)
    {
        if (funcs.ma_sound_is_playing(_ref) == 1)
        {
            funcs.ma_sound_stop(_ref);
        }
        ma_result result;
        result = funcs.ma_sound_seek_to_pcm_frame(_ref, frameIndex);
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Sound seeking error: {result}");
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="time">Time in milliseconds</param>
    public unsafe void SeekMsec(ulong time)
    {
        if (funcs.ma_sound_is_playing(_ref) == 1)
        {
            funcs.ma_sound_stop(_ref);
        }
        ma_result result;
        uint sample_rate;
        funcs.ma_sound_get_data_format(_ref, null, null, &sample_rate, null, 0);
        result = funcs.ma_sound_seek_to_pcm_frame(
            _ref,
            (ulong)(time * ((float)sample_rate / 1000f))
        );
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Sound seeking error: {result}");
        }
    }

    public unsafe struct DataFormat
    {
        public Format Format;
        public uint Channels;
        public uint SampleRate;
        public fixed byte ChannelMap[254];
    }

    public unsafe DataFormat GetDataFormat()
    {
        Format format;
        uint channels;
        uint sampleRate;
        byte[] channelMap = new byte[254];
        fixed (byte* ch = channelMap)
        {
            ma_result result;
            result = funcs.ma_sound_get_data_format(_ref, &format, &channels, &sampleRate, ch, 254);
            Logger.ErrorDebug(ins: $"Error getting sound's Data Format: {result}");
            var ret = new DataFormat
            {
                Format = format,
                Channels = channels,
                SampleRate = sampleRate,
            };
            byte* ptr = ret.ChannelMap;
            ptr = ch;
            return ret;
        }
    }

    public unsafe ulong GetCursorPCM()
    {
        ma_result result;
        ulong ret;
        result = funcs.ma_sound_get_cursor_in_pcm_frames(_ref, &ret);
        Logger.ErrorDebug(ins: $"Error getting cursor: {result}");
        return ret;
    }

    public unsafe ulong GetLengthPCM()
    {
        ma_result result;
        ulong ret;
        result = funcs.ma_sound_get_length_in_pcm_frames(_ref, &ret);
        Logger.ErrorDebug(ins: $"Error getting length: {result}");
        return ret;
    }

    public unsafe float GetCursorSecs()
    {
        ma_result result;
        float ret;
        result = funcs.ma_sound_get_cursor_in_seconds(_ref, &ret);
        Logger.ErrorDebug(ins: $"Error getting cursor: {result}");
        return ret;
    }

    public unsafe float GetLengthSecs()
    {
        ma_result result;
        float ret;
        result = funcs.ma_sound_get_length_in_seconds(_ref, &ret);
        Logger.ErrorDebug(ins: $"Error getting length: {result}");
        return ret;
    }

    public delegate void EndCallbackDelegate(object userdata, Sound sound);
    private Type _userdata_type = typeof(object);
    private EndCallbackDelegate _end_callback_func = (_, _) => { };
    private object _userdata = new();

    /// <remarks>
    /// This is not type-safe.
    /// </remarks>
    /// <param name="func"></param>
    public unsafe void SetEndCallback(EndCallbackDelegate func, Type userdataType)
    {
        _end_callback_func = func;
        _userdata_type = userdataType;
        funcs.ma_sound_set_end_callback(
            _ref,
            (delegate* unmanaged[Cdecl]<void*, ma_sound*, void>)
                Marshal.GetFunctionPointerForDelegate(_end_callback),
            null
        );
    }

    internal unsafe void _end_callback(void* usr, ma_sound* snd)
    {
        _end_callback_func?.Invoke(Convert.ChangeType(_userdata, _userdata_type), this);
    }

    /* interface */

    public unsafe uint IsPlaying => funcs.ma_sound_is_playing(_ref);
    public unsafe ulong Time => funcs.ma_sound_get_time_in_pcm_frames(_ref);

    /// <summary>
    ///
    /// </summary>
    /// <remarks>
    /// This field does not exist in interface
    /// and is unique to <see cref="Sound"/>
    /// </remarks>
    public unsafe ulong TimeMsec => funcs.ma_sound_get_time_in_milliseconds(_ref);

    public unsafe float Volume
    {
        get => funcs.ma_sound_get_volume(_ref);
        set => funcs.ma_sound_set_volume(_ref, value);
    }
    public unsafe float Pan
    {
        get => funcs.ma_sound_get_pan(_ref);
        set => funcs.ma_sound_set_pan(_ref, value);
    }
    public unsafe PanMode PanMode
    {
        get => funcs.ma_sound_get_pan_mode(_ref);
        set => funcs.ma_sound_set_pan_mode(_ref, value);
    }
    public unsafe float Pitch
    {
        get => funcs.ma_sound_get_pitch(_ref);
        set => funcs.ma_sound_set_pitch(_ref, value);
    }

    /// <summary>
    /// Get the reference to the <see cref="Engine"/> this
    /// <see cref="Sound"/> belongs to.
    /// </summary>
    /// <remarks>
    /// The original implementation would return a pointer (yuck)
    /// </remarks>
    /// <returns></returns>
    public Engine GetEngine()
    {
        return _engine;
    }

    public unsafe void Start()
    {
        ma_result result;
        result = funcs.ma_sound_start(_ref);
        Logger.ErrorDebug(ins: $"Sound start error: {result}");
    }

    public unsafe void Stop()
    {
        ma_result result;
        result = funcs.ma_sound_stop(_ref);
        Logger.ErrorDebug(ins: $"Sound stop error: {result}");
    }

    public unsafe void StopFadePCM(ulong length)
    {
        ma_result result;
        result = funcs.ma_sound_stop_with_fade_in_pcm_frames(_ref, length);
        Logger.ErrorDebug(ins: $"Sound stop error: {result}");
    }

    public unsafe void StopFadeMsec(ulong length)
    {
        ma_result result;
        result = funcs.ma_sound_stop_with_fade_in_milliseconds(_ref, length);
        Logger.ErrorDebug(ins: $"Sound stop error: {result}");
    }

    /// <remarks>
    /// Should be converted to a bool.
    /// </remarks>
    public unsafe uint EnableSpatialization
    {
        get => funcs.ma_sound_is_spatialization_enabled(_ref);
        set => funcs.ma_sound_set_spatialization_enabled(_ref, value);
    }

    public unsafe Engine.Listener PinnedListener
    {
        get => new(funcs.ma_sound_get_pinned_listener_index(_ref)) { parent = _engine };
        set => funcs.ma_sound_set_pinned_listener_index(_ref, value.Index);
    }

    public unsafe Engine.Listener GetListener()
    {
        return new(funcs.ma_sound_get_listener_index(_ref)) { parent = _engine };
    }

    public unsafe Vec3f GetDirectionToListener()
    {
        return funcs.ma_sound_get_direction_to_listener(_ref);
    }

    public unsafe Vec3f Position
    {
        get => funcs.ma_sound_get_position(_ref);
        set => funcs.ma_sound_set_position(_ref, value.X, value.Y, value.Z);
    }
    public unsafe Vec3f Velocity
    {
        get => funcs.ma_sound_get_velocity(_ref);
        set => funcs.ma_sound_set_velocity(_ref, value.X, value.Y, value.Z);
    }
    public unsafe AttenuationModel AttenuationModel
    {
        get => funcs.ma_sound_get_attenuation_model(_ref);
        set => funcs.ma_sound_set_attenuation_model(_ref, value);
    }
    public unsafe Positioning Positioning
    {
        get => funcs.ma_sound_get_positioning(_ref);
        set => funcs.ma_sound_set_positioning(_ref, value);
    }
    public unsafe float RollOff
    {
        get => funcs.ma_sound_get_rolloff(_ref);
        set => funcs.ma_sound_set_rolloff(_ref, value);
    }
    public unsafe float MinGain
    {
        get => funcs.ma_sound_get_min_gain(_ref);
        set => funcs.ma_sound_set_min_gain(_ref, value);
    }
    public unsafe float MaxGain
    {
        get => funcs.ma_sound_get_max_gain(_ref);
        set => funcs.ma_sound_set_max_gain(_ref, value);
    }
    public unsafe float MinDistance
    {
        get => funcs.ma_sound_get_min_distance(_ref);
        set => funcs.ma_sound_set_min_distance(_ref, value);
    }
    public unsafe float MaxDistance
    {
        get => funcs.ma_sound_get_max_distance(_ref);
        set => funcs.ma_sound_set_max_distance(_ref, value);
    }
    public unsafe Cone Cone
    {
        get
        {
            float pInnerAngleInRadians,
                pOuterAngleInRadians,
                pOuterGain;
            funcs.ma_sound_get_cone(
                _ref,
                &pInnerAngleInRadians,
                &pOuterAngleInRadians,
                &pOuterGain
            );
            return new Cone(pInnerAngleInRadians, pOuterAngleInRadians, pOuterGain);
        }
        set =>
            funcs.ma_sound_set_cone(
                _ref,
                value.InnerAngleInRadians,
                value.OuterAngleInRadians,
                value.OuterGain
            );
    }
    public unsafe float DopplerFactor
    {
        get => funcs.ma_sound_get_doppler_factor(_ref);
        set => funcs.ma_sound_set_doppler_factor(_ref, value);
    }
    public unsafe float DirectionalAttenuationFactor
    {
        get => funcs.ma_sound_get_directional_attenuation_factor(_ref);
        set => funcs.ma_sound_set_directional_attenuation_factor(_ref, value);
    }

    public unsafe void SetFadePCM(float volumeStart, float volumeEnd, ulong fadeLength)
    {
        funcs.ma_sound_set_fade_in_pcm_frames(_ref, volumeStart, volumeEnd, fadeLength);
    }

    public unsafe void SetFadeMsec(float volumeStart, float volumeEnd, ulong fadeLength)
    {
        funcs.ma_sound_set_fade_in_milliseconds(_ref, volumeStart, volumeEnd, fadeLength);
    }

    public unsafe float GetCurrentFadeVolume()
    {
        return funcs.ma_sound_get_current_fade_volume(_ref);
    }

    public unsafe void ScheduleStartPCM(ulong globalTime)
    {
        funcs.ma_sound_set_start_time_in_pcm_frames(_ref, globalTime);
    }

    public unsafe void ScheduleStartMsec(ulong globalTime)
    {
        funcs.ma_sound_set_start_time_in_milliseconds(_ref, globalTime);
    }

    public unsafe void ScheduleStopPCM(ulong globalTime)
    {
        funcs.ma_sound_set_stop_time_in_pcm_frames(_ref, globalTime);
    }

    public unsafe void ScheduleStopMsec(ulong globalTime)
    {
        funcs.ma_sound_set_stop_time_in_milliseconds(_ref, globalTime);
    }

    public unsafe void ScheduleStopFadePCM(ulong globalTime, ulong fadeLength)
    {
        funcs.ma_sound_set_stop_time_with_fade_in_pcm_frames(_ref, globalTime, fadeLength);
    }

    public unsafe void ScheduleStopFadeMsec(ulong globalTime, ulong fadeLength)
    {
        funcs.ma_sound_set_stop_time_with_fade_in_milliseconds(_ref, globalTime, fadeLength);
    }

    /* -- Disposal --*/

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual unsafe void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (!disposing)
        {
            Logger.WarnDebug(ins: "Disposed from finalizer.");
        }

        fixed (ma_sound* g = &_sound)
        {
            funcs.ma_sound_uninit(g);
        }
        _disposed = true;
    }

    ~Sound()
    {
        Dispose(false);
    }
}

public class SoundConfig
{
    private ma_sound_config _conf;

    public SoundConfig()
    {
        _conf = funcs.ma_sound_config_init();
    }

    public unsafe SoundConfig(Engine engine)
    {
        _conf = funcs.ma_sound_config_init_2(engine.__unsafeRef());
    }

    internal unsafe ma_sound_config* __unsafeRef()
    {
        fixed (ma_sound_config* c = &_conf)
        {
            return c;
        }
    }
}
