using Naquadic.Common.Enums;
using Naquadic.Logging;

namespace Naquadic.Thin;

public class SoundGroup : IDisposable, ISoundNode
{
    private ma_sound _group;
    private Engine _engine;
    private unsafe ma_sound* _ref;
    private bool _disposed;

    public unsafe SoundGroup(Engine engine, uint flags, SoundGroup parent)
    {
        ma_result result;
        _engine = engine;
        fixed (ma_sound* g = &_group)
        {
            result = funcs.ma_sound_group_init(
                engine.__unsafeRef(),
                flags,
                parent.__unsafeRef(),
                g
            );
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Sound Group initialiation error: {result}");
        }
        _ref = __unsafeRef();
    }

    public unsafe SoundGroup(Engine engine, SoundGroupConfig config)
    {
        ma_result result;
        _engine = engine;
        fixed (ma_sound* g = &_group)
        {
            result = funcs.ma_sound_group_init_ex(engine.__unsafeRef(), config.__unsafeRef(), g);
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Sound Group initialiation error: {result}");
        }
        _ref = __unsafeRef();
    }

    internal unsafe ma_sound* __unsafeRef()
    {
        fixed (ma_sound* c = &_group)
        {
            return c;
        }
    }

    /// <summary>
    /// Get the reference to the <see cref="Engine"/> this
    /// <see cref="SoundGroup"/> belongs to.
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
        result = funcs.ma_sound_group_start(_ref);
        Logger.ErrorDebug(ins: $"Sound Group start error: {result}");
    }

    public unsafe void Stop()
    {
        ma_result result;
        result = funcs.ma_sound_group_stop(_ref);
        Logger.ErrorDebug(ins: $"Sound Group stop error: {result}");
    }

    public unsafe float Volume
    {
        get => funcs.ma_sound_group_get_volume(_ref);
        set => funcs.ma_sound_group_set_volume(_ref, value);
    }
    public unsafe float Pan
    {
        get => funcs.ma_sound_group_get_pan(_ref);
        set => funcs.ma_sound_group_set_pan(_ref, value);
    }
    public unsafe PanMode PanMode
    {
        get => funcs.ma_sound_group_get_pan_mode(_ref);
        set => funcs.ma_sound_group_set_pan_mode(_ref, value);
    }
    public unsafe float Pitch
    {
        get => funcs.ma_sound_group_get_pitch(_ref);
        set => funcs.ma_sound_group_set_pitch(_ref, value);
    }

    /// <remarks>
    /// Should be converted to a bool.
    /// </remarks>
    public unsafe uint EnableSpatialization
    {
        get => funcs.ma_sound_group_is_spatialization_enabled(_ref);
        set => funcs.ma_sound_group_set_spatialization_enabled(_ref, value);
    }

    public unsafe Engine.Listener PinnedListener
    {
        get => new(funcs.ma_sound_group_get_pinned_listener_index(_ref)) { parent = _engine };
        set => funcs.ma_sound_group_set_pinned_listener_index(_ref, value.Index);
    }

    public unsafe Engine.Listener GetListener()
    {
        return new(funcs.ma_sound_group_get_listener_index(_ref)) { parent = _engine };
    }

    public unsafe Vec3f GetDirectionToListener()
    {
        return funcs.ma_sound_group_get_direction_to_listener(_ref);
    }

    public unsafe Vec3f Position
    {
        get => funcs.ma_sound_group_get_position(_ref);
        set => funcs.ma_sound_group_set_position(_ref, value.X, value.Y, value.Z);
    }
    public unsafe Vec3f Velocity
    {
        get => funcs.ma_sound_group_get_velocity(_ref);
        set => funcs.ma_sound_group_set_velocity(_ref, value.X, value.Y, value.Z);
    }
    public unsafe AttenuationModel AttenuationModel
    {
        get => funcs.ma_sound_group_get_attenuation_model(_ref);
        set => funcs.ma_sound_group_set_attenuation_model(_ref, value);
    }
    public unsafe Positioning Positioning
    {
        get => funcs.ma_sound_group_get_positioning(_ref);
        set => funcs.ma_sound_group_set_positioning(_ref, value);
    }
    public unsafe float RollOff
    {
        get => funcs.ma_sound_group_get_rolloff(_ref);
        set => funcs.ma_sound_group_set_rolloff(_ref, value);
    }
    public unsafe float MinGain
    {
        get => funcs.ma_sound_group_get_min_gain(_ref);
        set => funcs.ma_sound_group_set_min_gain(_ref, value);
    }
    public unsafe float MaxGain
    {
        get => funcs.ma_sound_group_get_max_gain(_ref);
        set => funcs.ma_sound_group_set_max_gain(_ref, value);
    }
    public unsafe float MinDistance
    {
        get => funcs.ma_sound_group_get_min_distance(_ref);
        set => funcs.ma_sound_group_set_min_distance(_ref, value);
    }
    public unsafe float MaxDistance
    {
        get => funcs.ma_sound_group_get_max_distance(_ref);
        set => funcs.ma_sound_group_set_max_distance(_ref, value);
    }
    public unsafe Cone Cone
    {
        get
        {
            float pInnerAngleInRadians,
                pOuterAngleInRadians,
                pOuterGain;
            funcs.ma_sound_group_get_cone(
                _ref,
                &pInnerAngleInRadians,
                &pOuterAngleInRadians,
                &pOuterGain
            );
            return new Cone(pInnerAngleInRadians, pOuterAngleInRadians, pOuterGain);
        }
        set =>
            funcs.ma_sound_group_set_cone(
                _ref,
                value.InnerAngleInRadians,
                value.OuterAngleInRadians,
                value.OuterGain
            );
    }
    public unsafe float DopplerFactor
    {
        get => funcs.ma_sound_group_get_doppler_factor(_ref);
        set => funcs.ma_sound_group_set_doppler_factor(_ref, value);
    }
    public unsafe float DirectionalAttenuationFactor
    {
        get => funcs.ma_sound_group_get_directional_attenuation_factor(_ref);
        set => funcs.ma_sound_group_set_directional_attenuation_factor(_ref, value);
    }

    public unsafe uint IsPlaying => funcs.ma_sound_group_is_playing(_ref);

    public unsafe ulong TimePCM => funcs.ma_sound_group_get_time_in_pcm_frames(_ref);

    public unsafe void SetFadePCM(float volumeStart, float volumeEnd, ulong fadeLength)
    {
        funcs.ma_sound_group_set_fade_in_pcm_frames(_ref, volumeStart, volumeEnd, fadeLength);
    }

    public unsafe void SetFadeMsec(float volumeStart, float volumeEnd, ulong fadeLength)
    {
        funcs.ma_sound_group_set_fade_in_milliseconds(_ref, volumeStart, volumeEnd, fadeLength);
    }

    public unsafe float GetCurrentFadeVolume()
    {
        return funcs.ma_sound_group_get_current_fade_volume(_ref);
    }

    public unsafe void ScheduleStartPCM(ulong globalTime)
    {
        funcs.ma_sound_group_set_start_time_in_pcm_frames(_ref, globalTime);
    }

    public unsafe void ScheduleStartMsec(ulong globalTime)
    {
        funcs.ma_sound_group_set_start_time_in_milliseconds(_ref, globalTime);
    }

    public unsafe void ScheduleStopPCM(ulong globalTime)
    {
        funcs.ma_sound_group_set_stop_time_in_pcm_frames(_ref, globalTime);
    }

    public unsafe void ScheduleStopMsec(ulong globalTime)
    {
        funcs.ma_sound_group_set_stop_time_in_milliseconds(_ref, globalTime);
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

        fixed (ma_sound* g = &_group)
        {
            funcs.ma_sound_group_uninit(g);
        }
        _disposed = true;
    }

    ~SoundGroup()
    {
        Dispose(false);
    }
}

public class SoundGroupConfig
{
    private ma_sound_config _conf;

    public SoundGroupConfig()
    {
        _conf = funcs.ma_sound_group_config_init();
    }

    public unsafe SoundGroupConfig(Engine engine)
    {
        _conf = funcs.ma_sound_group_config_init_2(engine.__unsafeRef());
    }

    internal unsafe ma_sound_config* __unsafeRef()
    {
        fixed (ma_sound_config* c = &_conf)
        {
            return c;
        }
    }
}
