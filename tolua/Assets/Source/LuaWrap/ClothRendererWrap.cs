using UnityEngine;
using System;
using LuaInterface;

public class ClothRendererWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateClothRenderer),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("pauseWhenNotVisible", get_pauseWhenNotVisible, set_pauseWhenNotVisible),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateClothRenderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ClothRenderer obj = new ClothRenderer();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ClothRenderer.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ClothRenderer));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ClothRenderer", typeof(ClothRenderer), regs, fields, "UnityEngine.Renderer");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pauseWhenNotVisible(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pauseWhenNotVisible");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pauseWhenNotVisible on a nil value");
			}
		}

		ClothRenderer obj = (ClothRenderer)o;
		LuaScriptMgr.Push(L, obj.pauseWhenNotVisible);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pauseWhenNotVisible(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pauseWhenNotVisible");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pauseWhenNotVisible on a nil value");
			}
		}

		ClothRenderer obj = (ClothRenderer)o;
		obj.pauseWhenNotVisible = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

