using System.Runtime.CompilerServices;

namespace Naquadic.Logging;

/// <summary>
/// <para>References: https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797</para>
/// <para>Singleton: https://refactoring.guru/design-patterns/singleton/csharp/example#example-1</para>
/// </summary>
///
public sealed class Logger
{
    private Logger() { }

    private static Logger? _instance;
    private static readonly object _lock = new();

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                _instance ??= new();
            }
        }
        return _instance;
    }

    private static readonly string ESC = "\x1b[";

    /* Single Modes */
    private static readonly string FG_PREFIX = ESC + "38;5;";
    private static readonly string BG_PREFIX = ESC + "48;5;";
    public static readonly string MODE_RESET = ESC + "0m";
    public static readonly string MODE_BOLD = ESC + "1m";
    public static readonly string MODE_BOLD_RESET = ESC + "22m";
    public static readonly string MODE_DIM = ESC + "2m";
    public static readonly string MODE_DIM_RESET = ESC + "22m";
    public static readonly string MODE_ITALIC = ESC + "3m";
    public static readonly string MODE_ITALIC_RESET = ESC + "23m";
    public static readonly string MODE_UNDERLINE = ESC + "4m";
    public static readonly string MODE_UNDERLINE_RESET = ESC + "24m";
    public static readonly string MODE_BLINKING = ESC + "5m";
    public static readonly string MODE_BLINKING_RESET = ESC + "25m";
    public static readonly string MODE_REVERSE = ESC + "7m";
    public static readonly string MODE_REVERSE_RESET = ESC + "27m";
    public static readonly string MODE_HIDDEN = ESC + "8m";
    public static readonly string MODE_HIDDEN_RESET = ESC + "28m";
    public static readonly string MODE_STRIKE = ESC + "9m";
    public static readonly string MODE_STRIKE_RESET = ESC + "29m";

    /// <summary>
    /// References: https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797#colors--graphics-mode
    /// </summary>
    /// <param name="modes"></param>
    /// <returns></returns>

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string CombineMode(params Codes[] modes)
    {
        return ESC + string.Join(';', modes.Cast<int>()) + "m";
    }

    /// <summary>
    /// References: https://user-images.githubusercontent.com/995050/47952855-ecb12480-df75-11e8-89d4-ac26c50e80b9.png
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Fg256(byte code)
    {
        return FG_PREFIX + code + "m";
    }

    /// <summary>
    /// References: https://user-images.githubusercontent.com/995050/47952855-ecb12480-df75-11e8-89d4-ac26c50e80b9.png
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Bg256(byte code)
    {
        return BG_PREFIX + code + "m";
    }

    /// <summary>
    /// References: https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797#rgb-colors
    /// </summary>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TrueFg(byte red, byte green, byte blue)
    {
        return FG_PREFIX + $"{red};{green};{blue}" + "m";
    }

    /// <summary>
    /// References: https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797#rgb-colors
    /// </summary>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TrueBg(byte red, byte green, byte blue)
    {
        return BG_PREFIX + $"{red};{green};{blue}" + "m";
    }

    /// <summary>
    /// Logs out info-style. The strings after the first one are indented
    /// and placed on newlines. Formatting is resetted after each line.
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void Info(params string[] ins)
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite, Codes.BackgroundCyan)
            + "info"
            + MODE_RESET
            + " ";
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }

    /// <summary>
    /// Logs out error-style. The strings after the first one are indented
    /// and placed on newlines. Formatting is resetted after each line.
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void Error(params string[] ins)
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite, Codes.BackgroundRed)
            + "error"
            + MODE_RESET
            + " ";
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }

    /// <summary>
    /// Logs out warn-style. The strings after the first one are indented
    /// and placed on newlines. Formatting is resetted after each line.
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void Warn(params string[] ins)
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite)
            + Bg256(214)
            + "warn"
            + MODE_RESET
            + " ";
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }

    /// <summary>
    /// <see cref="Info(string[])"/> with line number and file name.
    /// `ins` should be passed by name with an array for this method to work correctly.
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void InfoDebug(
        [CallerFilePath] string file = "",
        [CallerMemberName] string member = "",
        [CallerLineNumber] int line = 0,
        params string[] ins
    )
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite, Codes.BackgroundCyan)
            + "info"
            + MODE_RESET
            + " "
            + CombineMode(Codes.ITALIC, Codes.ForegroundYellow)
            + $"{file}>{member}:{line}"
            + MODE_RESET
            + " ";
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }

    /// <summary>
    /// <see cref="Error(string[])"/> with line number and file name.
    /// `ins` should be passed by name with an array for this method to work correctly.
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void ErrorDebug(
        [CallerFilePath] string file = "",
        [CallerMemberName] string member = "",
        [CallerLineNumber] int line = 0,
        params string[] ins
    )
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite, Codes.BackgroundRed)
            + "error"
            + MODE_RESET
            + " "
            + CombineMode(Codes.ITALIC, Codes.ForegroundYellow)
            + $"{file}>{member}:{line}"
            + MODE_RESET
            + " ";
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }

    /// <summary>
    /// <see cref="Warn(string[])"/> with line number and file name.
    /// `ins` should be passed by name with an array for this method to work correctly.
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void WarnDebug(
        [CallerFilePath] string file = "",
        [CallerMemberName] string member = "",
        [CallerLineNumber] int line = 0,
        params string[] ins
    )
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite)
            + Bg256(214)
            + "warn"
            + MODE_RESET
            + " "
            + CombineMode(Codes.ITALIC, Codes.ForegroundYellow)
            + $"{file}>{member}:{line}"
            + MODE_RESET
            + " ";
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }

    /// <summary>
    /// <see cref="Info(string[])"/> with timestamps
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void InfoTimestamped(params string[] ins)
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite, Codes.BackgroundCyan)
            + "info"
            + MODE_RESET
            + " "
            + CombineMode(Codes.ForegroundGreen)
            + DateTime.Now.ToString("HH:mm:ss")
            + " "
            + MODE_RESET;
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }

    /// <summary>
    /// <see cref="Error(string[])"/> with timestamps
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void ErrorTimestamped(params string[] ins)
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite, Codes.BackgroundRed)
            + "error"
            + MODE_RESET
            + " "
            + CombineMode(Codes.ForegroundGreen)
            + DateTime.Now.ToString("HH:mm:ss")
            + " "
            + MODE_RESET;
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }

    /// <summary>
    /// <see cref="Error(string[])"/> with timestamps
    /// </summary>
    /// <param name="ins">Output (formatted) strings</param>
    public static void WarnTimestamped(params string[] ins)
    {
        string prefix =
            CombineMode(Codes.RESET, Codes.ForegroundWhite)
            + Bg256(214)
            + "warn"
            + MODE_RESET
            + " "
            + CombineMode(Codes.ForegroundGreen)
            + DateTime.Now.ToString("HH:mm:ss")
            + " "
            + MODE_RESET;
        Console.WriteLine(prefix + string.Join($"{MODE_RESET}\n-   ", ins));
    }
}

/// <summary>
/// To be used in conjunction with <see cref="Logger.CombineMode(Codes[])"/>
/// </summary>
public enum Codes : int
{
    /* Formatting */

    RESET = 0,
    BOLD = 1,
    BOLD_RESET = 22,
    DIM = 2,
    DIM_RESET = 22,
    ITALIC = 3,
    ITALIC_RESET = 23,
    UNDERLINE = 4,
    UNDERLINE_RESET = 24,
    BLINKING = 5,
    BLINKING_RESET = 25,
    REVERSE = 7,
    REVERSE_RESET = 27,
    HIDDEN = 8,
    HIDDEN_RESET = 28,
    STRIKE = 9,
    STRIKE_RESET = 29,

    /* 8-16 Colors */

    // - 8
    ForegroundBlack = 30,
    ForegroundRed = 31,
    ForegroundGreen = 32,
    ForegroundYellow = 33,
    ForegroundBlue = 34,
    ForegroundMagenta = 35,
    ForegroundCyan = 36,
    ForegroundWhite = 37,
    ForegroundDefault = 39,
    ForegroundReset = 0,
    BackgroundBlack = 40,
    BackgroundRed = 41,
    BackgroundGreen = 42,
    BackgroundYellow = 43,
    BackgroundBlue = 44,
    BackgroundMagenta = 45,
    BackgroundCyan = 46,
    BackgroundWhite = 47,
    BackgroundDefault = 49,
    BackgroundReset = 0,

    // - 16

    ForegroundBrightBlack = 90,
    ForegroundBrightRed = 91,
    ForegroundBrightGreen = 92,
    ForegroundBrightYellow = 93,
    ForegroundBrightBlue = 94,
    ForegroundBrightMagenta = 95,
    ForegroundBrightCyan = 96,
    ForegroundBrightWhite = 97,
    BackgroundBrightBlack = 100,
    BackgroundBrightRed = 101,
    BackgroundBrightGreen = 102,
    BackgroundBrightYellow = 103,
    BackgroundBrightBlue = 104,
    BackgroundBrightMagenta = 105,
    BackgroundBrightCyan = 106,
    BackgroundBrightWhite = 107,
}
