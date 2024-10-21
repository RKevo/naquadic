namespace Naquadic.Miniaudio.Windows
{
    internal partial struct ma_decoding_backend_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format preferredFormat;

        [NativeTypeName("ma_uint32")]
        public uint seekPointCount;
    }
}
