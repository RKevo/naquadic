using Naquadic.Logging;
using Naquadic.Miniaudio.Windows;

class Program
{
    static void Main(string[] args)
    {
        TestLog();
    }

    public static void TestLog()
    {
        Logger.Info("Log");
        Logger.InfoTimestamped("LogTimestamped");
        Logger.InfoDebug(ins: "LogDebug");
        Logger.Warn("Log");
        Logger.WarnTimestamped("LogTimestamped");
        Logger.WarnDebug(ins: "LogDebug");
        Logger.Error("Log");
        Logger.ErrorTimestamped("LogTimestamped");
        Logger.ErrorDebug(ins: "LogDebug");
    }
}
