namespace Naquadic.Miniaudio.Windows
{
    internal partial struct ma_waveform_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public ma_waveform_type type;

        public double amplitude;

        public double frequency;
    }
}
