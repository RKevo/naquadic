namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_context_config
    {
        public ma_log* pLog;

        public ma_thread_priority threadPriority;

        [NativeTypeName("size_t")]
        public nuint threadStackSize;

        public void* pUserData;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7260_C5")]
        public _alsa_e__Struct alsa;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7264_C5")]
        public _pulse_e__Struct pulse;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7270_C5")]
        public _coreaudio_e__Struct coreaudio;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7277_C5")]
        public _jack_e__Struct jack;

        public ma_backend_callbacks custom;

        internal partial struct _alsa_e__Struct
        {
            [NativeTypeName("ma_bool32")]
            public uint useVerboseDeviceEnumeration;
        }

        internal unsafe partial struct _pulse_e__Struct
        {
            [NativeTypeName("const char *")]
            public sbyte* pApplicationName;

            [NativeTypeName("const char *")]
            public sbyte* pServerName;

            [NativeTypeName("ma_bool32")]
            public uint tryAutoSpawn;
        }

        internal partial struct _coreaudio_e__Struct
        {
            public ma_ios_session_category sessionCategory;

            [NativeTypeName("ma_uint32")]
            public uint sessionCategoryOptions;

            [NativeTypeName("ma_bool32")]
            public uint noAudioSessionActivate;

            [NativeTypeName("ma_bool32")]
            public uint noAudioSessionDeactivate;
        }

        internal unsafe partial struct _jack_e__Struct
        {
            [NativeTypeName("const char *")]
            public sbyte* pClientName;

            [NativeTypeName("ma_bool32")]
            public uint tryStartServer;
        }
    }
}
