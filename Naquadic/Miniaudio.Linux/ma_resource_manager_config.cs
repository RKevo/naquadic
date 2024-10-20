namespace Naquadic.Miniaudio.Linux
{
    internal unsafe partial struct ma_resource_manager_config
    {
        public ma_allocation_callbacks allocationCallbacks;

        public ma_log* pLog;

        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format decodedFormat;

        [NativeTypeName("ma_uint32")]
        public uint decodedChannels;

        [NativeTypeName("ma_uint32")]
        public uint decodedSampleRate;

        [NativeTypeName("ma_uint32")]
        public uint jobThreadCount;

        [NativeTypeName("size_t")]
        public nuint jobThreadStackSize;

        [NativeTypeName("ma_uint32")]
        public uint jobQueueCapacity;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_vfs *")]
        public void* pVFS;

        public ma_decoding_backend_vtable** ppCustomDecodingBackendVTables;

        [NativeTypeName("ma_uint32")]
        public uint customDecodingBackendCount;

        public void* pCustomDecodingBackendUserData;
    }
}
