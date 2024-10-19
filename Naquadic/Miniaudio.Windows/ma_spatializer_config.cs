namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_spatializer_config
    {
        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapIn;

        [NativeTypeName("ma_attenuation_model")]
        public Naquadic.Common.Enums.AttenuationModel attenuationModel;

        [NativeTypeName("ma_positioning")]
        public Naquadic.Common.Enums.Positioning positioning;

        public ma_handedness handedness;

        public float minGain;

        public float maxGain;

        public float minDistance;

        public float maxDistance;

        public float rolloff;

        public float coneInnerAngleInRadians;

        public float coneOuterAngleInRadians;

        public float coneOuterGain;

        public float dopplerFactor;

        public float directionalAttenuationFactor;

        public float minSpatializationChannelGain;

        [NativeTypeName("ma_uint32")]
        public uint gainSmoothTimeInFrames;
    }
}
