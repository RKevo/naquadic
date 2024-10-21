namespace Naquadic.Miniaudio.Windows
{
    internal partial struct ma_encoder_config
    {
        public ma_encoding_format encodingFormat;

        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public ma_allocation_callbacks allocationCallbacks;
    }
}
