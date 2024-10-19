using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Linux
{
    [StructLayout(LayoutKind.Explicit)]
    internal partial struct ma_biquad_coefficient
    {
        [FieldOffset(0)]
        public float f32;

        [FieldOffset(0)]
        [NativeTypeName("ma_int32")]
        public int s32;
    }
}
