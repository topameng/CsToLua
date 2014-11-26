using UnityEngine;
using System;
using LuaInterface;

public class ForceMode2DWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Force", ForceMode2D.Force),
		new LuaEnum("Impulse", ForceMode2D.Impulse),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ForceMode2D", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ForceMode2D", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ForceMode2D o = (ForceMode2D)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

