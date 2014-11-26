using UnityEngine;
using System;
using LuaInterface;

public class ColorSpaceWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Uninitialized", ColorSpace.Uninitialized),
		new LuaEnum("Gamma", ColorSpace.Gamma),
		new LuaEnum("Linear", ColorSpace.Linear),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ColorSpace", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ColorSpace", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ColorSpace o = (ColorSpace)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

