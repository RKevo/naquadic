namespace Naquadic.Miniaudio.Windows
{
    internal partial struct ma_pulsewave_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double dutyCycle;

        public double amplitude;

        public double frequency;
    }
}
