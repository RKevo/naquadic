namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_bpf
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint bpf2Count;

        public ma_bpf2* pBPF2;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }
}
