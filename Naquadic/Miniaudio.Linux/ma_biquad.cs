namespace Naquadic.Miniaudio.Linux
{
    internal unsafe partial struct ma_biquad
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_biquad_coefficient b0;

        public ma_biquad_coefficient b1;

        public ma_biquad_coefficient b2;

        public ma_biquad_coefficient a1;

        public ma_biquad_coefficient a2;

        public ma_biquad_coefficient* pR1;

        public ma_biquad_coefficient* pR2;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }
}
