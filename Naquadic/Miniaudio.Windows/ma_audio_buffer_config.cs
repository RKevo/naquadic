namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_audio_buffer_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint64")]
        public ulong sizeInFrames;

        [NativeTypeName("const void *")]
        public void* pData;

        public ma_allocation_callbacks allocationCallbacks;
    }
}
