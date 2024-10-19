namespace Naquadic.Thin;

public class ResourceManager : IDisposable
{
    private ma_resource_manager _res;
    private bool _disposed;

    public unsafe ResourceManager()
    {
        ma_result result;
        fixed (ma_resource_manager* r = &_res)
        {
            result = funcs.ma_resource_manager_init(null, r);
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Console.WriteLine($"Resource Manager initialiation error: {result}");
        }
    }

    public unsafe ResourceManager(ResourceManagerConfig config)
    {
        ma_result result;
        fixed (ma_resource_manager* r = &_res)
        {
            result = funcs.ma_resource_manager_init(config.__unsafeRef(), r);
        }
        if (result != ma_result.MA_SUCCESS)
        {
            Console.WriteLine($"Resource Manager initialiation error: {result}");
        }
    }

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

        fixed (ma_resource_manager* r = &_res)
        {
            funcs.ma_resource_manager_uninit(r);
        }
        _disposed = true;
    }

    ~ResourceManager()
    {
        Dispose(false);
    }
}

public class ResourceManagerConfig
{
    private ma_resource_manager_config _conf;

    public ResourceManagerConfig()
    {
        _conf = funcs.ma_resource_manager_config_init();
    }

    internal unsafe ma_resource_manager_config* __unsafeRef()
    {
        fixed (ma_resource_manager_config* c = &_conf)
        {
            return c;
        }
    }
}
