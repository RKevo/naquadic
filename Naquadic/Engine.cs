namespace Naquadic.Thin;

public class Engine : IDisposable
{
    private ma_engine _engine;
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
            Console.WriteLine($"Engine initialiation error: {result}");
        }
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
            Console.WriteLine($"Engine initialiation error: {result}");
        }
    }

    public unsafe ma_engine* __unsafeRef()
    {
        fixed (ma_engine* c = &_engine)
        {
            return c;
        }
    }

    public unsafe void Start()
    {
        ma_result result;
        fixed (ma_engine* e = &_engine)
        {
            result = funcs.ma_engine_start(e);
        }
        Console.WriteLine($"Engine start error: {result}");
    }

    public unsafe void Stop()
    {
        ma_result result;
        fixed (ma_engine* e = &_engine)
        {
            result = funcs.ma_engine_stop(e);
        }
        Console.WriteLine($"Engine stop error: {result}");
    }

    public unsafe ulong Time
    {
        get
        {
            fixed (ma_engine* e = &_engine)
            {
                return funcs.ma_engine_get_time_in_pcm_frames(e);
            }
        }
        set
        {
            fixed (ma_engine* e = &_engine)
            {
                funcs.ma_engine_set_time_in_pcm_frames(e, value);
            }
        }
    }
    public unsafe ulong TimeMsec
    {
        get
        {
            fixed (ma_engine* e = &_engine)
            {
                return funcs.ma_engine_get_time_in_milliseconds(e);
            }
        }
        set
        {
            fixed (ma_engine* e = &_engine)
            {
                funcs.ma_engine_set_time_in_milliseconds(e, value);
            }
        }
    }

    public unsafe uint Channels
    {
        get
        {
            fixed (ma_engine* e = &_engine)
            {
                return funcs.ma_engine_get_channels(e);
            }
        }
    }

    public unsafe uint SampleRate
    {
        get
        {
            fixed (ma_engine* e = &_engine)
            {
                return funcs.ma_engine_get_sample_rate(e);
            }
        }
    }

    public unsafe float Volume
    {
        get
        {
            fixed (ma_engine* e = &_engine)
            {
                return funcs.ma_engine_get_volume(e);
            }
        }
        set
        {
            fixed (ma_engine* e = &_engine)
            {
                funcs.ma_engine_set_volume(e, value);
            }
        }
    }

    public unsafe float Gain
    {
        get
        {
            fixed (ma_engine* e = &_engine)
            {
                return funcs.ma_engine_get_gain_db(e);
            }
        }
        set
        {
            fixed (ma_engine* e = &_engine)
            {
                funcs.ma_engine_set_gain_db(e, value);
            }
        }
    }

    public record Listener(uint Index)
    {
        public required Engine parent;
    }

    public unsafe uint ListenerCount
    {
        get
        {
            fixed (ma_engine* e = &_engine)
            {
                return funcs.ma_engine_get_listener_count(e);
            }
        }
    }

    public unsafe Listener FindClosestListener(float x, float y, float z)
    {
        fixed (ma_engine* e = &_engine)
        {
            return new Listener(funcs.ma_engine_find_closest_listener(e, x, y, z))
            {
                parent = this
            };
        }
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
            Console.WriteLine("Disposed from finalizer.");
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

    public unsafe ma_engine_config* __unsafeRef()
    {
        fixed (ma_engine_config* c = &_conf)
        {
            return c;
        }
    }
}
