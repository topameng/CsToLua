using UnityEngine;
using System;
using LuaInterface;

public class SleepTimeoutWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateSleepTimeout),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("NeverSleep", get_NeverSleep, null),
		new LuaField("SystemSetting", get_SystemSetting, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSleepTimeout(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SleepTimeout obj = new SleepTimeout();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SleepTimeout.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(SleepTimeout));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SleepTimeout", typeof(SleepTimeout), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NeverSleep(IntPtr L)
	{
		LuaScriptMgr.Push(L, SleepTimeout.NeverSleep);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SystemSetting(IntPtr L)
	{
		LuaScriptMgr.Push(L, SleepTimeout.SystemSetting);
		return 1;
	}
}

