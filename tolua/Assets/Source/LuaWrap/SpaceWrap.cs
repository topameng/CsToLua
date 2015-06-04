using System;
using UnityEngine;
using LuaInterface;

public class SpaceWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("World", GetWorld),
		new LuaMethod("Self", GetSelf),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Space", typeof(UnityEngine.Space), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWorld(IntPtr L)
	{
		LuaScriptMgr.Push(L, Space.World);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSelf(IntPtr L)
	{
		LuaScriptMgr.Push(L, Space.Self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Space o = (Space)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

