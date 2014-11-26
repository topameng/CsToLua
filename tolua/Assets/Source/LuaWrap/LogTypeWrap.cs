using UnityEngine;
using System;
using LuaInterface;

public class LogTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Error", LogType.Error),
		new LuaEnum("Assert", LogType.Assert),
		new LuaEnum("Warning", LogType.Warning),
		new LuaEnum("Log", LogType.Log),
		new LuaEnum("Exception", LogType.Exception),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LogType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.LogType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		LogType o = (LogType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

