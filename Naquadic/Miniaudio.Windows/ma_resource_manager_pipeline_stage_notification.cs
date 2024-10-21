namespace Naquadic.Miniaudio.Windows
{
    internal unsafe partial struct ma_resource_manager_pipeline_stage_notification
    {
        [NativeTypeName("ma_async_notification *")]
        public void* pNotification;

        [NativeTypeName("ma_fence *")]
        public Naquadic.Common.Structs.Fence* pFence;
    }
}
