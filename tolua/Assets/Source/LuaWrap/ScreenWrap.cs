using UnityEngine;
using System;
using LuaInterface;

public class ScreenWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetResolution", SetResolution),
		new LuaMethod("New", _CreateScreen),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("resolutions", get_resolutions, null),
		new LuaField("GetResolution", get_GetResolution, null),
		new LuaField("currentResolution", get_currentResolution, null),
		new LuaField("showCursor", get_showCursor, set_showCursor),
		new LuaField("lockCursor", get_lockCursor, set_lockCursor),
		new LuaField("width", get_width, null),
		new LuaField("height", get_height, null),
		new LuaField("dpi", get_dpi, null),
		new LuaField("fullScreen", get_fullScreen, set_fullScreen),
		new LuaField("autorotateToPortrait", get_autorotateToPortrait, set_autorotateToPortrait),
		new LuaField("autorotateToPortraitUpsideDown", get_autorotateToPortraitUpsideDown, set_autorotateToPortraitUpsideDown),
		new LuaField("autorotateToLandscapeLeft", get_autorotateToLandscapeLeft, set_autorotateToLandscapeLeft),
		new LuaField("autorotateToLandscapeRight", get_autorotateToLandscapeRight, set_autorotateToLandscapeRight),
		new LuaField("orientation", get_orientation, set_orientation),
		new LuaField("sleepTimeout", get_sleepTimeout, set_sleepTimeout),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateScreen(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Screen obj = new Screen();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Screen.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Screen));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Screen", typeof(Screen), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resolutions(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Screen.resolutions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GetResolution(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Screen.GetResolution);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentResolution(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Screen.currentResolution);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_showCursor(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.showCursor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lockCursor(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.lockCursor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_width(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.width);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_height(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.height);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dpi(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.dpi);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fullScreen(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.fullScreen);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autorotateToPortrait(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.autorotateToPortrait);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autorotateToPortraitUpsideDown(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.autorotateToPortraitUpsideDown);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autorotateToLandscapeLeft(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.autorotateToLandscapeLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autorotateToLandscapeRight(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.autorotateToLandscapeRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orientation(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, Screen.orientation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sleepTimeout(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.sleepTimeout);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_showCursor(IntPtr L)
	{
		Screen.showCursor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lockCursor(IntPtr L)
	{
		Screen.lockCursor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fullScreen(IntPtr L)
	{
		Screen.fullScreen = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autorotateToPortrait(IntPtr L)
	{
		Screen.autorotateToPortrait = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autorotateToPortraitUpsideDown(IntPtr L)
	{
		Screen.autorotateToPortraitUpsideDown = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autorotateToLandscapeLeft(IntPtr L)
	{
		Screen.autorotateToLandscapeLeft = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autorotateToLandscapeRight(IntPtr L)
	{
		Screen.autorotateToLandscapeRight = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orientation(IntPtr L)
	{
		Screen.orientation = LuaScriptMgr.GetNetObject<ScreenOrientation>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sleepTimeout(IntPtr L)
	{
		Screen.sleepTimeout = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetResolution(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Screen.SetResolution(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			Screen.SetResolution(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Screen.SetResolution");
		}

		return 0;
	}
}

