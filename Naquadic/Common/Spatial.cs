/// Unification
namespace Naquadic.Common.Spatial;

public struct Vec3f
{
    public float X;
    public float Y;
    public float Z;

    public Vec3f(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vec3f Init(float x, float y, float z)
    {
        return funcs.ma_vec3f_init_3f(x, y, z);
    }
	
    public static float LengthSquared(this Vec3f v)
    {
        return funcs.ma_vec3f_len2(v);
    }

    public static float Length(this Vec3f v)
    {
        return funcs.ma_vec3f_len(v);
    }

    public static Vec3f operator +(Vec3f v) => v;

    public static Vec3f operator -(Vec3f v) => funcs.ma_vec3f_neg(v);

    public static Vec3f operator +(Vec3f a, Vec3f b) => Init(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

    public static Vec3f operator -(Vec3f a, Vec3f b) => funcs.ma_vec3f_sub(a, b);

    /// <summary>
    /// Dot product
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float operator *(Vec3f a, Vec3f b) => funcs.ma_vec3f_dot(a, b);
}

public record Cone(float InnerAngleInRadians, float OuterAngleInRadians, float OuterGain);
