using System;
using UnityEngine;
using LuaInterface;

public class QueueModeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("CompleteOthers", GetCompleteOthers),
		new LuaMethod("PlayNow", GetPlayNow),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.QueueMode", typeof(UnityEngine.QueueMode), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCompleteOthers(IntPtr L)
	{
		LuaScriptMgr.Push(L, QueueMode.CompleteOthers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPlayNow(IntPtr L)
	{
		LuaScriptMgr.Push(L, QueueMode.PlayNow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		QueueMode o = (QueueMode)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

