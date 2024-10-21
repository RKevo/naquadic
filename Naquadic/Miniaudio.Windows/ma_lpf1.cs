namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_lpf1
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_biquad_coefficient a;

        public ma_biquad_coefficient* pR1;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }
}
