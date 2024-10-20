using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_resource_manager_data_buffer
    {
        public ma_data_source_base ds;

        public ma_resource_manager* pResourceManager;

        public ma_resource_manager_data_buffer_node* pNode;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint32")]
        public uint executionCounter;

        [NativeTypeName("ma_uint32")]
        public uint executionPointer;

        [NativeTypeName("ma_uint64")]
        public ulong seekTargetInPCMFrames;

        [NativeTypeName("ma_bool32")]
        public uint seekToCursorOnNextRead;

        public ma_result result;

        [NativeTypeName("ma_bool32")]
        public uint isLooping;

        public ma_atomic_bool32 isConnectorInitialized;

        [NativeTypeName("__AnonymousRecord_miniaudio_L10386_C5")]
        public _connector_e__Union connector;

        [StructLayout(LayoutKind.Explicit)]
        internal partial struct _connector_e__Union
        {
            [FieldOffset(0)]
            public ma_decoder decoder;

            [FieldOffset(0)]
            public ma_audio_buffer buffer;

            [FieldOffset(0)]
            public ma_paged_audio_buffer pagedBuffer;
        }
    }
}
