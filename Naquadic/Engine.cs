using Naquadic.Common.Spatial;
using Naquadic.Logging;

namespace Naquadic.Thin;

public class Engine : IDisposable
{
    private ma_engine _engine;
    private unsafe ma_engine* _ref;
    private bool _disposed;

    public unsafe Engine()
    {
        ma_result result;
        fixed (ma_engine* e = &_engine)
        {
            result = funcs.ma_engine_init(null, e);
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Engine initialiation error: {result}");
        }
        _ref = __unsafeRef();
    }

    public unsafe Engine(EngineConfig config)
    {
        ma_result result;
        fixed (ma_engine* e = &_engine)
        {
            result = funcs.ma_engine_init(config.__unsafeRef(), e);
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Logger.ErrorDebug(ins: $"Engine initialiation error: {result}");
        }
    }

    internal unsafe ma_engine* __unsafeRef()
    {
        fixed (ma_engine* c = &_engine)
        {
            return c;
        }
    }

    public unsafe void Start()
    {
        ma_result result;
        result = funcs.ma_engine_start(_ref);
        Logger.ErrorDebug(ins: $"Engine start error: {result}");
    }

    public unsafe void Stop()
    {
        ma_result result;
        result = funcs.ma_engine_stop(_ref);
        Logger.ErrorDebug(ins: $"Engine stop error: {result}");
    }

    public unsafe void PlaySound(string filePath) { }

    public unsafe ulong Time
    {
        get => funcs.ma_engine_get_time_in_pcm_frames(_ref);
        set => funcs.ma_engine_set_time_in_pcm_frames(_ref, value);
    }
    public unsafe ulong TimeMsec
    {
        get => funcs.ma_engine_get_time_in_milliseconds(_ref);
        set => funcs.ma_engine_set_time_in_milliseconds(_ref, value);
    }

    public unsafe uint Channels
    {
        get { return funcs.ma_engine_get_channels(_ref); }
    }

    public unsafe uint SampleRate
    {
        get { return funcs.ma_engine_get_sample_rate(_ref); }
    }

    public unsafe float Volume
    {
        get => funcs.ma_engine_get_volume(_ref);
        set => funcs.ma_engine_set_volume(_ref, value);
    }

    public unsafe float Gain
    {
        get => funcs.ma_engine_get_gain_db(_ref);
        set => funcs.ma_engine_set_gain_db(_ref, value);
    }

    public record Listener(uint Index)
    {
        public required Engine parent;
        public unsafe Vec3f Position
        {
            get => funcs.ma_engine_listener_get_position(parent.__unsafeRef(), Index);
            set =>
                funcs.ma_engine_listener_set_position(
                    parent.__unsafeRef(),
                    Index,
                    value.X,
                    value.Y,
                    value.Z
                );
        }
        public unsafe Vec3f Direction
        {
            get => funcs.ma_engine_listener_get_direction(parent.__unsafeRef(), Index);
            set =>
                funcs.ma_engine_listener_set_direction(
                    parent.__unsafeRef(),
                    Index,
                    value.X,
                    value.Y,
                    value.Z
                );
        }
        public unsafe Vec3f Velocity
        {
            get => funcs.ma_engine_listener_get_velocity(parent.__unsafeRef(), Index);
            set =>
                funcs.ma_engine_listener_set_velocity(
                    parent.__unsafeRef(),
                    Index,
                    value.X,
                    value.Y,
                    value.Z
                );
        }
        public unsafe Vec3f WorldUp
        {
            get => funcs.ma_engine_listener_get_world_up(parent.__unsafeRef(), Index);
            set =>
                funcs.ma_engine_listener_set_world_up(
                    parent.__unsafeRef(),
                    Index,
                    value.X,
                    value.Y,
                    value.Z
                );
        }
        public unsafe Cone Cone
        {
            get
            {
                float pInnerAngleInRadians,
                    pOuterAngleInRadians,
                    pOuterGain;
                funcs.ma_engine_listener_get_cone(
                    parent.__unsafeRef(),
                    Index,
                    &pInnerAngleInRadians,
                    &pOuterAngleInRadians,
                    &pOuterGain
                );
                return new Cone(pInnerAngleInRadians, pOuterAngleInRadians, pOuterGain);
            }
            set =>
                funcs.ma_engine_listener_set_cone(
                    parent.__unsafeRef(),
                    Index,
                    value.InnerAngleInRadians,
                    value.OuterAngleInRadians,
                    value.OuterGain
                );
        }

        /// <remarks>
        /// Should be converted to a bool.
        /// </remarks>
        public unsafe uint IsEnabled
        {
            get => funcs.ma_engine_listener_is_enabled(parent.__unsafeRef(), Index);
            set => funcs.ma_engine_listener_set_enabled(parent.__unsafeRef(), Index, value);
        }
    }

    public unsafe uint ListenerCount
    {
        get => funcs.ma_engine_get_listener_count(_ref);
    }

    public unsafe Listener FindClosestListener(float x, float y, float z)
    {
        return new Listener(funcs.ma_engine_find_closest_listener(_ref, x, y, z)) { parent = this };
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

        fixed (ma_engine* e = &_engine)
        {
            funcs.ma_engine_uninit(e);
        }
        _disposed = true;
    }

    ~Engine()
    {
        Dispose(false);
    }
}

public class EngineConfig
{
    private ma_engine_config _conf;

    public EngineConfig()
    {
        _conf = funcs.ma_engine_config_init();
    }

    internal unsafe ma_engine_config* __unsafeRef()
    {
        fixed (ma_engine_config* c = &_conf)
        {
            return c;
        }
    }
}
