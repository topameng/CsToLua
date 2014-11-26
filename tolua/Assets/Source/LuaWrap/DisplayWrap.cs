using UnityEngine;
using System;
using LuaInterface;

public class DisplayWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Activate", Activate),
		new LuaMethod("SetRenderingResolution", SetRenderingResolution),
		new LuaMethod("New", _CreateDisplay),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("displays", get_displays, set_displays),
		new LuaField("renderingWidth", get_renderingWidth, null),
		new LuaField("renderingHeight", get_renderingHeight, null),
		new LuaField("systemWidth", get_systemWidth, null),
		new LuaField("systemHeight", get_systemHeight, null),
		new LuaField("colorBuffer", get_colorBuffer, null),
		new LuaField("depthBuffer", get_depthBuffer, null),
		new LuaField("main", get_main, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDisplay(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Display class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Display));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Display", typeof(Display), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_displays(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Display.displays);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderingWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderingWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderingWidth on a nil value");
			}
		}

		Display obj = (Display)o;
		LuaScriptMgr.Push(L, obj.renderingWidth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderingHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderingHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderingHeight on a nil value");
			}
		}

		Display obj = (Display)o;
		LuaScriptMgr.Push(L, obj.renderingHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_systemWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name systemWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index systemWidth on a nil value");
			}
		}

		Display obj = (Display)o;
		LuaScriptMgr.Push(L, obj.systemWidth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_systemHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name systemHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index systemHeight on a nil value");
			}
		}

		Display obj = (Display)o;
		LuaScriptMgr.Push(L, obj.systemHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorBuffer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorBuffer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorBuffer on a nil value");
			}
		}

		Display obj = (Display)o;
		LuaScriptMgr.PushValue(L, obj.colorBuffer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depthBuffer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depthBuffer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depthBuffer on a nil value");
			}
		}

		Display obj = (Display)o;
		LuaScriptMgr.PushValue(L, obj.depthBuffer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_main(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Display.main);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_displays(IntPtr L)
	{
		Display.displays = LuaScriptMgr.GetNetObject<Display[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Activate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Display obj = LuaScriptMgr.GetNetObject<Display>(L, 1);
		obj.Activate();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetRenderingResolution(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Display obj = LuaScriptMgr.GetNetObject<Display>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.SetRenderingResolution(arg0,arg1);
		return 0;
	}
}

