using UnityEngine;
using System;

namespace UnityArsenal.Core.Log
{
    public class UnityEditorLog : ILog
    {
        public void Log(string message, LogType logType, UnityEngine.Object contextObject = null, params object[] formatArgs)
        {
            const string logMessageFormat = "{0}: {1}";
            var utcNow = DateTime.UtcNow;
            var logMessage = string.Format(logMessageFormat, utcNow, string.Format(message, formatArgs));

            if (contextObject != null)
            {
                Debug.logger.Log(logMessage, logType, contextObject);
            }
            else
            {
                Debug.logger.Log(logMessage, logType);
            }
        }

        public void Log(Exception ex, UnityEngine.Object contextObject = null)
        {
            const string logExceptionMessageFormat = "Exception: {0}{1}, Stack Trace:{2}{3}";
            var logExceptionMessage = string.Format(logExceptionMessageFormat, ex.Message, Environment.NewLine, Environment.NewLine, ex.StackTrace);

            Log(logExceptionMessage, LogType.Exception, contextObject);
        }
    }
}