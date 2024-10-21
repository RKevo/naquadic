namespace Naquadic.Miniaudio.Linux
{
    internal partial struct ma_panner
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_pan_mode")]
        public Naquadic.Common.Enums.PanMode mode;

        public float pan;
    }
}
