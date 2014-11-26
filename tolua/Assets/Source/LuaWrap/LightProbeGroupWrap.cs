using UnityEngine;
using System;
using LuaInterface;

public class LightProbeGroupWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateLightProbeGroup),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("probePositions", get_probePositions, set_probePositions),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLightProbeGroup(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LightProbeGroup obj = new LightProbeGroup();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LightProbeGroup.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LightProbeGroup));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LightProbeGroup", typeof(LightProbeGroup), regs, fields, "UnityEngine.Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_probePositions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name probePositions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index probePositions on a nil value");
			}
		}

		LightProbeGroup obj = (LightProbeGroup)o;
		LuaScriptMgr.PushArray(L, obj.probePositions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_probePositions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name probePositions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index probePositions on a nil value");
			}
		}

		LightProbeGroup obj = (LightProbeGroup)o;
		obj.probePositions = LuaScriptMgr.GetNetObject<Vector3[]>(L, 3);
		return 0;
	}
}

