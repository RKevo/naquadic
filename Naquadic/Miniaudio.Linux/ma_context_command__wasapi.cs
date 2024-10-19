using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Linux
{
    internal unsafe partial struct ma_context_command__wasapi
    {
        public int code;

        [NativeTypeName("ma_event *")]
        public void** pEvent;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7290_C5")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        internal partial struct _data_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L7292_C9")]
            public _quit_e__Struct quit;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L7296_C9")]
            public _createAudioClient_e__Struct createAudioClient;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L7303_C9")]
            public _releaseAudioClient_e__Struct releaseAudioClient;

            internal partial struct _quit_e__Struct
            {
                public int _unused;
            }

            internal unsafe partial struct _createAudioClient_e__Struct
            {
                public ma_device_type deviceType;

                public void* pAudioClient;

                public void** ppAudioClientService;

                public ma_result* pResult;
            }

            internal unsafe partial struct _releaseAudioClient_e__Struct
            {
                public ma_device* pDevice;

                public ma_device_type deviceType;
            }
        }
    }
}
