namespace Naquadic.Common.Enums;

public enum PanMode
{
    Balance = 0,
    Pan,
}

public enum AttenuationModel
{
    None,
    Inverse,
    Linear,
    Exponential,
}

public enum Positioning
{
    Absolute,
    Relative,
}

public enum Format
{
    Unknown = 0,
    U8 = 1,
    S16 = 2,
    S24 = 3,
    S32 = 4,
    F32 = 5,
    Count,
}
