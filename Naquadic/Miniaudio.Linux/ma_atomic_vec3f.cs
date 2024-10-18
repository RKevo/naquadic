namespace Naquadic.Miniaudio.Linux
{
    public partial struct ma_atomic_vec3f
    {
        public Vec3f v;

        [NativeTypeName("ma_spinlock")]
        public uint @lock;
    }
}
