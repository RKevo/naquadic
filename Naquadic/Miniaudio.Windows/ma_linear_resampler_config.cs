namespace Naquadic.Miniaudio.Windows
{
    internal partial struct ma_linear_resampler_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        [NativeTypeName("ma_uint32")]
        public uint lpfOrder;

        public double lpfNyquistFactor;
    }
}
