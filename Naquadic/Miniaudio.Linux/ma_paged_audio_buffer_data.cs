namespace Naquadic.Miniaudio.Linux
{
    internal unsafe partial struct ma_paged_audio_buffer_data
    {
        [NativeTypeName("ma_format")]
        public Naquadic.Common.Enums.Format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_paged_audio_buffer_page head;

        public ma_paged_audio_buffer_page* pTail;
    }
}
