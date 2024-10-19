using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Linux
{
    [StructLayout(LayoutKind.Explicit)]
    internal partial struct ma_timer
    {
        [FieldOffset(0)]
        [NativeTypeName("ma_int64")]
        public long counter;

        [FieldOffset(0)]
        public double counterD;
    }
}
