namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_data_converter_config
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

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapIn;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapOut;

        public ma_dither_mode ditherMode;

        public ma_channel_mix_mode channelMixMode;

        [NativeTypeName("ma_bool32")]
        public uint calculateLFEFromSpatialChannels;

        public float** ppChannelWeights;

        [NativeTypeName("ma_bool32")]
        public uint allowDynamicSampleRate;

        public ma_resampler_config resampling;
    }
}
