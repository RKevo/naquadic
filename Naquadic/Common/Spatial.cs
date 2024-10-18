/// Unification
namespace Naquadic.Common.Spatial;

public struct Vec3f
{
    public float X;
    public float Y;
    public float Z;
}

public record Cone (float InnerAngleInRadians, float OuterAngleInRadians, float OuterGain);
