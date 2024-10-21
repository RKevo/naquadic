namespace Naquadic.Miniaudio.Linux
{
    internal unsafe partial struct ma_data_converter
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format formatIn;

        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format formatOut;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        public ma_dither_mode ditherMode;

        public ma_data_converter_execution_path executionPath;

        public ma_channel_converter channelConverter;

        public ma_resampler resampler;

        [NativeTypeName("ma_bool8")]
        public byte hasPreFormatConversion;

        [NativeTypeName("ma_bool8")]
        public byte hasPostFormatConversion;

        [NativeTypeName("ma_bool8")]
        public byte hasChannelConverter;

        [NativeTypeName("ma_bool8")]
        public byte hasResampler;

        [NativeTypeName("ma_bool8")]
        public byte isPassthrough;

        [NativeTypeName("ma_bool8")]
        public byte _ownsHeap;

        public void* _pHeap;
    }
}
