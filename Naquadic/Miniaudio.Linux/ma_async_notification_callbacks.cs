namespace Naquadic.Miniaudio.Linux
{
    public unsafe partial struct ma_async_notification_callbacks
    {
        [NativeTypeName("void (*)(ma_async_notification *)")]
        public delegate* unmanaged[Cdecl]<void*, void> onSignal;
    }
}
