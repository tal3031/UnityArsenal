using System;

namespace UnityArsenal.Core.Log
{
    public class LogManager
    {
        public LogManager(ILog logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("log", "log cannot be null");
            }

            Logger = logger;
        }

        public static ILog Logger
        {
            get;
            private set;
        }
    }
}
