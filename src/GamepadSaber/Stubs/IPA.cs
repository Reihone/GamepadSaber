using System;

namespace IPA
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute : Attribute
    {
        public PluginAttribute(RuntimeOptions options) { }
    }

    public enum RuntimeOptions
    {
        SingleStartInit = 0
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class OnEnableAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class OnDisableAttribute : Attribute { }

    namespace Logging
    {
        public class Logger
        {
            public void Debug(string s) { }
            public void Info(string s) { }
            public void Warn(string s) { }
            public void Error(string s) { }
        }
    }
}
