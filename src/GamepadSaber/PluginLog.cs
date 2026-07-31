using IPA.Logging;

namespace GamepadSaber
{
    internal static class PluginLog
    {
        public static Logger Logger { get; set; }
        public static void Debug(string s) => Logger?.Debug(s);
        public static void Info(string s) => Logger?.Info(s);
        public static void Warn(string s) => Logger?.Warn(s);
        public static void Error(string s) => Logger?.Error(s);
    }
}
