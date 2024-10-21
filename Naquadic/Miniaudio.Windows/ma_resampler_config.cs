namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_resampler_config
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        public ma_resample_algorithm algorithm;

        public ma_resampling_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

        [NativeTypeName("__AnonymousRecord_miniaudio_L5367_C5")]
        public _linear_e__Struct linear;

        internal partial struct _linear_e__Struct
        {
            [NativeTypeName("ma_uint32")]
            public uint lpfOrder;
        }
    }
}
