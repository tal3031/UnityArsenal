using System;
using UnityEngine;

namespace UnityArsenal.Core.Log
{
    public class UnityRuntimeLog : ILog
    {
        public void Log(string message, LogType logType, UnityEngine.Object contextObject = null, params object[] formatArgs)
        {
            var logMessage = string.Format(message, formatArgs);

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
            if (contextObject != null)
            {
                Debug.logger.LogException(ex, contextObject);
            }
            else
            {
                Debug.logger.LogException(ex);
            }
        }
    }
}
