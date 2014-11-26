using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class StaticBatchingUtilityWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Combine", Combine),
		new LuaMethod("New", _CreateStaticBatchingUtility),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateStaticBatchingUtility(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			StaticBatchingUtility obj = new StaticBatchingUtility();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: StaticBatchingUtility.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(StaticBatchingUtility));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.StaticBatchingUtility", typeof(StaticBatchingUtility), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Combine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
			StaticBatchingUtility.Combine(arg0);
			return 0;
		}
		else if (count == 2)
		{
			GameObject[] objs0 = LuaScriptMgr.GetArrayObject<GameObject>(L, 1);
			GameObject arg1 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
			StaticBatchingUtility.Combine(objs0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: StaticBatchingUtility.Combine");
		}

		return 0;
	}
}

