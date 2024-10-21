namespace Naquadic.Miniaudio.Linux
{
    internal partial struct ma_bpf_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double cutoffFrequency;

        [NativeTypeName("ma_uint32")]
        public uint order;
    }
}
