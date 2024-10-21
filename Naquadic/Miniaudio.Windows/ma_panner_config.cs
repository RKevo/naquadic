namespace Naquadic.Miniaudio.Windows
{
    internal partial struct ma_panner_config
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
