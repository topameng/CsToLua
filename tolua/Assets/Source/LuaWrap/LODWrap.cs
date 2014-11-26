using UnityEngine;
using System;
using LuaInterface;

public class LODWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateLOD),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("screenRelativeTransitionHeight", get_screenRelativeTransitionHeight, set_screenRelativeTransitionHeight),
		new LuaField("renderers", get_renderers, set_renderers),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLOD(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			Renderer[] objs1 = LuaScriptMgr.GetArrayObject<Renderer>(L, 2);
			LOD obj = new LOD(arg0,objs1);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			LOD obj = new LOD();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LOD.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LOD));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LOD", typeof(LOD), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_screenRelativeTransitionHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name screenRelativeTransitionHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index screenRelativeTransitionHeight on a nil value");
			}
		}

		LOD obj = (LOD)o;
		LuaScriptMgr.Push(L, obj.screenRelativeTransitionHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderers");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderers on a nil value");
			}
		}

		LOD obj = (LOD)o;
		LuaScriptMgr.PushArray(L, obj.renderers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_screenRelativeTransitionHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name screenRelativeTransitionHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index screenRelativeTransitionHeight on a nil value");
			}
		}

		LOD obj = (LOD)o;
		obj.screenRelativeTransitionHeight = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderers");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderers on a nil value");
			}
		}

		LOD obj = (LOD)o;
		obj.renderers = LuaScriptMgr.GetNetObject<Renderer[]>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

