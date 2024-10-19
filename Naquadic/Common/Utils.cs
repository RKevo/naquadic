using System.Linq;
using System.Text;

namespace Naquadic.Common;

public static class Utils
{
    public static unsafe sbyte* LendString(string s)
    {
        sbyte[] chars = (sbyte[])(Array) Encoding.UTF8.GetBytes(s + char.MinValue);
		fixed (sbyte* r = chars) {
			return r;
		}
    }
}
