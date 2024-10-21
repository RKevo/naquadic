namespace Naquadic.Miniaudio.Linux
{
    internal partial struct ma_pcm_rb
    {
        public ma_data_source_base ds;

        public ma_rb rb;

        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;
    }
}
