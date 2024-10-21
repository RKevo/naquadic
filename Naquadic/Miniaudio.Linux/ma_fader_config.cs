namespace Naquadic.Miniaudio.Linux
{
    internal partial struct ma_fader_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;
    }
}
