using UnityEngine;
using System.Collections;

public static class Debugger
{
    public static void Log(string str, params object[] args)
    {
        str = string.Format(str, args);
        Debug.Log(str);
    }

    public static void LogError(string str, params object[] args)
    {
        str = string.Format(str, args);
        Debug.LogError(str);
    }
}
