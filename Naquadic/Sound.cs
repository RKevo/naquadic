using Naquadic.Common.Enums;
using Naquadic.Logging;

namespace Naquadic.Thin;

public class Sound : IDisposable, ISoundNode
{
    private ma_sound _sound;
    private Engine _engine;
    private unsafe ma_sound* _ref;
    private bool _disposed;

    public unsafe Sound(string filePath, uint flags, SoundGroup group) { }

    internal unsafe ma_sound* __unsafeRef()
    {
        fixed (ma_sound* c = &_sound)
        {
            return c;
        }
    }


	/* interface*/

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
        Logger.ErrorDebug(ins: $"Sound Group start error: {result}");
    }

    public unsafe void Stop()
    {
        ma_result result;
        result = funcs.ma_sound_stop(_ref);
        Logger.ErrorDebug(ins: $"Sound Group stop error: {result}");
    }

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

    public unsafe uint IsPlaying => funcs.ma_sound_is_playing(_ref);

    public unsafe ulong TimePCM => funcs.ma_sound_get_time_in_pcm_frames(_ref);

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
