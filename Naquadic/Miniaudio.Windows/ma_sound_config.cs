namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_sound_config
    {
        [NativeTypeName("const char *")]
        public sbyte* pFilePath;

        [NativeTypeName("const wchar_t *")]
        public ushort* pFilePathW;

        [NativeTypeName("ma_data_source *")]
        public void* pDataSource;

        [NativeTypeName("ma_node *")]
        public void* pInitialAttachment;

        [NativeTypeName("ma_uint32")]
        public uint initialAttachmentInputBusIndex;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        public ma_mono_expansion_mode monoExpansionMode;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint32")]
        public uint volumeSmoothTimeInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong initialSeekPointInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong rangeBegInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong rangeEndInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong loopPointBegInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong loopPointEndInPCMFrames;

        [NativeTypeName("ma_bool32")]
        public uint isLooping;

        [NativeTypeName("ma_sound_end_proc")]
        public delegate* unmanaged[Cdecl]<void*, ma_sound*, void> endCallback;

        public void* pEndCallbackUserData;

        public ma_resource_manager_pipeline_notifications initNotifications;

        [NativeTypeName("ma_fence *")]
        public Naquadic.Common.Structs.Fence* pDoneFence;
    }
}
