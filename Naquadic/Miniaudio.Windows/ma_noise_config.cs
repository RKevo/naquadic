namespace Naquadic.Miniaudio.Windows
{
    internal partial struct ma_noise_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_noise_type type;

        [NativeTypeName("ma_int32")]
        public int seed;

        public double amplitude;

        [NativeTypeName("ma_bool32")]
        public uint duplicateChannels;
    }
}
