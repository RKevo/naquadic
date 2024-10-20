namespace Naquadic.Miniaudio.Linux
{
    internal unsafe partial struct ma_channel_converter_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("const ma_channel *")]
        public byte* pChannelMapIn;

        [NativeTypeName("const ma_channel *")]
        public byte* pChannelMapOut;

        public ma_channel_mix_mode mixingMode;

        [NativeTypeName("ma_bool32")]
        public uint calculateLFEFromSpatialChannels;

        public float** ppWeights;
    }
}
