namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_audio_buffer_ref
    {
        public ma_data_source_base ds;

        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint64")]
        public ulong cursor;

        [NativeTypeName("ma_uint64")]
        public ulong sizeInFrames;

        [NativeTypeName("const void *")]
        public void* pData;
    }
}
