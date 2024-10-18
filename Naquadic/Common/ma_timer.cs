using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Windows
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct ma_timer
    {
        [FieldOffset(0)]
        [NativeTypeName("ma_int64")]
        public long counter;

        [FieldOffset(0)]
        public double counterD;
    }
}
