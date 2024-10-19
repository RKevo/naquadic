using System.Runtime.CompilerServices;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vec3f Init(float x, float y, float z)
    {
        return funcs.ma_vec3f_init_3f(x, y, z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly float LengthSquared()
    {
        return funcs.ma_vec3f_len2(this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly float Length()
    {
        return funcs.ma_vec3f_len(this);
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

    /// <summary>
    /// Distance between two vectors
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float operator /(Vec3f a, Vec3f b) => funcs.ma_vec3f_dist(a, b);

    /// <summary>
    /// Normalize vector
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vec3f operator ~(Vec3f v) => funcs.ma_vec3f_normalize(v);

    /// <summary>
    /// Cross Product
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float operator %(Vec3f a, Vec3f b) => funcs.ma_vec3f_dist(a, b);
}

public record Cone(float InnerAngleInRadians, float OuterAngleInRadians, float OuterGain);
