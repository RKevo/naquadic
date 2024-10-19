namespace Naquadic.Common;

public class FlagBuilder<T>
    where T : Enum
{
    private uint compiledFlags = 0;

    public FlagBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        compiledFlags = 0;
    }

    public FlagBuilder<T> Add(T flag) {
		compiledFlags |= (uint)(object)flag;
		return this;
	}

	public uint Compile() {
		return compiledFlags;
	}
}
