using System;
using UnityEngine;

namespace UnityArsenal.Core.Log
{
    public interface ILog
    {
        void Log(string message, LogType logType, UnityEngine.Object contextObject = null, params object[] formatArgs);
        void Log(Exception ex, UnityEngine.Object contextObject = null);
    }
}