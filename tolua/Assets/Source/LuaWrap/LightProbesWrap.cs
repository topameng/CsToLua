using UnityEngine;
using System;
using LuaInterface;

public class LightProbesWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetInterpolatedLightProbe", GetInterpolatedLightProbe),
		new LuaMethod("New", _CreateLightProbes),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("positions", get_positions, null),
		new LuaField("coefficients", get_coefficients, set_coefficients),
		new LuaField("count", get_count, null),
		new LuaField("cellCount", get_cellCount, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLightProbes(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LightProbes obj = new LightProbes();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LightProbes.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LightProbes));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LightProbes", typeof(LightProbes), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_positions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positions on a nil value");
			}
		}

		LightProbes obj = (LightProbes)o;
		LuaScriptMgr.PushArray(L, obj.positions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_coefficients(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name coefficients");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index coefficients on a nil value");
			}
		}

		LightProbes obj = (LightProbes)o;
		LuaScriptMgr.PushArray(L, obj.coefficients);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name count");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index count on a nil value");
			}
		}

		LightProbes obj = (LightProbes)o;
		LuaScriptMgr.Push(L, obj.count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cellCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellCount on a nil value");
			}
		}

		LightProbes obj = (LightProbes)o;
		LuaScriptMgr.Push(L, obj.cellCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_coefficients(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name coefficients");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index coefficients on a nil value");
			}
		}

		LightProbes obj = (LightProbes)o;
		obj.coefficients = LuaScriptMgr.GetNetObject<Single[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInterpolatedLightProbe(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		LightProbes obj = LuaScriptMgr.GetNetObject<LightProbes>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Renderer arg1 = LuaScriptMgr.GetNetObject<Renderer>(L, 3);
		float[] objs2 = LuaScriptMgr.GetArrayNumber<float>(L, 4);
		obj.GetInterpolatedLightProbe(arg0,arg1,objs2);
		return 0;
	}
}

