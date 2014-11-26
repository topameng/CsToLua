using UnityEngine;
using System;
using LuaInterface;

public class SpritePackingModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Tight", SpritePackingMode.Tight),
		new LuaEnum("Rectangle", SpritePackingMode.Rectangle),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SpritePackingMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.SpritePackingMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		SpritePackingMode o = (SpritePackingMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

