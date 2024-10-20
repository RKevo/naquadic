using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_decoder
    {
        public ma_data_source_base ds;

        [NativeTypeName("ma_data_source *")]
        public void* pBackend;

        [NativeTypeName("const ma_decoding_backend_vtable *")]
        public ma_decoding_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

        [NativeTypeName("ma_decoder_read_proc")]
        public delegate* unmanaged[Cdecl]<ma_decoder*, void*, nuint, nuint*, ma_result> onRead;

        [NativeTypeName("ma_decoder_seek_proc")]
        public delegate* unmanaged[Cdecl]<ma_decoder*, long, ma_seek_origin, ma_result> onSeek;

        [NativeTypeName("ma_decoder_tell_proc")]
        public delegate* unmanaged[Cdecl]<ma_decoder*, long*, ma_result> onTell;

        public void* pUserData;

        [NativeTypeName("ma_uint64")]
        public ulong readPointerInPCMFrames;

        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format outputFormat;

        [NativeTypeName("ma_uint32")]
        public uint outputChannels;

        [NativeTypeName("ma_uint32")]
        public uint outputSampleRate;

        public ma_data_converter converter;

        public void* pInputCache;

        [NativeTypeName("ma_uint64")]
        public ulong inputCacheCap;

        [NativeTypeName("ma_uint64")]
        public ulong inputCacheConsumed;

        [NativeTypeName("ma_uint64")]
        public ulong inputCacheRemaining;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("__AnonymousRecord_miniaudio_L9946_C5")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        internal partial struct _data_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L9948_C9")]
            public _vfs_e__Struct vfs;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L9953_C9")]
            public _memory_e__Struct memory;

            internal unsafe partial struct _vfs_e__Struct
            {
                [NativeTypeName("ma_vfs *")]
                public void* pVFS;

                [NativeTypeName("ma_vfs_file")]
                public void* file;
            }

            internal unsafe partial struct _memory_e__Struct
            {
                [NativeTypeName("const ma_uint8 *")]
                public byte* pData;

                [NativeTypeName("size_t")]
                public nuint dataSize;

                [NativeTypeName("size_t")]
                public nuint currentReadPos;
            }
        }
    }
}
