namespace Naquadic.Miniaudio.Windows
{
    public unsafe partial struct ma_sound_inlined
    {
        public ma_sound sound;

        public ma_sound_inlined* pNext;

        public ma_sound_inlined* pPrev;
    }
}
