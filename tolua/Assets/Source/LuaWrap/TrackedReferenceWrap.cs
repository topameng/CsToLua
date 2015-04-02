using System;
using UnityEngine;
using LuaInterface;

public class TrackedReferenceWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("New", _CreateTrackedReference),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTrackedReference(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TrackedReference class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(TrackedReference));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TrackedReference", typeof(TrackedReference), regs, fields, typeof(System.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		TrackedReference obj = LuaScriptMgr.GetVarObject(L, 1) as TrackedReference;
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TrackedReference obj = LuaScriptMgr.GetTrackedObject<TrackedReference>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		TrackedReference arg0 = LuaScriptMgr.GetVarObject(L, 1) as TrackedReference;
		TrackedReference arg1 = LuaScriptMgr.GetVarObject(L, 2) as TrackedReference;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

