namespace Naquadic.Miniaudio.Linux
{
    internal partial struct ma_job_queue_config
    {
        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint32")]
        public uint capacity;
    }
}
