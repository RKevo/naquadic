namespace Naquadic.Miniaudio.Linux
{
    public enum ma_resource_manager_data_source_flags
    {
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_STREAM = 0x00000001,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_DECODE = 0x00000002,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_ASYNC = 0x00000004,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_WAIT_INIT = 0x00000008,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_UNKNOWN_LENGTH = 0x00000010,
    }
}
