using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Linux
{
    internal unsafe partial struct ma_resampler
    {
        [NativeTypeName("ma_resampling_backend *")]
        public void* pBackend;

        public ma_resampling_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        [NativeTypeName("__AnonymousRecord_miniaudio_L5384_C5")]
        public _state_e__Union state;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        internal partial struct _state_e__Union
        {
            [FieldOffset(0)]
            public ma_linear_resampler linear;
        }
    }
}
