namespace Naquadic.Miniaudio.Windows
{
    internal partial struct ma_hpf_config
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
