using UnityEngine;
using System;
using UnityEngine.Rendering;
using LuaInterface;

public class ColorWriteMaskWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Alpha", ColorWriteMask.Alpha),
		new LuaEnum("Blue", ColorWriteMask.Blue),
		new LuaEnum("Green", ColorWriteMask.Green),
		new LuaEnum("Red", ColorWriteMask.Red),
		new LuaEnum("All", ColorWriteMask.All),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Rendering.ColorWriteMask", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.Rendering.ColorWriteMask", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ColorWriteMask o = (ColorWriteMask)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

