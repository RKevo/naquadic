using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Linux
{
    internal partial struct ma_resource_manager_data_supply
    {
        public ma_resource_manager_data_supply_type type;

        [NativeTypeName("__AnonymousRecord_miniaudio_L10334_C5")]
        public _backend_e__Union backend;

        [StructLayout(LayoutKind.Explicit)]
        internal partial struct _backend_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L10336_C9")]
            public _encoded_e__Struct encoded;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L10341_C9")]
            public _decoded_e__Struct decoded;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L10350_C9")]
            public _decodedPaged_e__Struct decodedPaged;

            internal unsafe partial struct _encoded_e__Struct
            {
                [NativeTypeName("const void *")]
                public void* pData;

                [NativeTypeName("size_t")]
                public nuint sizeInBytes;
            }

            internal unsafe partial struct _decoded_e__Struct
            {
                [NativeTypeName("const void *")]
                public void* pData;

                [NativeTypeName("ma_uint64")]
                public ulong totalFrameCount;

                [NativeTypeName("ma_uint64")]
                public ulong decodedFrameCount;

                [NativeTypeName("ma_format")]
                public Naquadic.Common.Enums.Format format;

                [NativeTypeName("ma_uint32")]
                public uint channels;

                [NativeTypeName("ma_uint32")]
                public uint sampleRate;
            }

            internal partial struct _decodedPaged_e__Struct
            {
                public ma_paged_audio_buffer_data data;

                [NativeTypeName("ma_uint64")]
                public ulong decodedFrameCount;

                [NativeTypeName("ma_uint32")]
                public uint sampleRate;
            }
        }
    }
}
