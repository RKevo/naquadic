namespace Naquadic.Common.Structs;

public unsafe struct Fence
{
    /// <summary>
    /// pthread which has no bindings bc thats how it is
    /// </summary>
    public void* Event;

    public uint Counter;
}
