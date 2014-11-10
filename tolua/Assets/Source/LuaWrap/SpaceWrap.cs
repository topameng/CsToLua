using UnityEngine;
using System;
using LuaInterface;

public class SpaceWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("World", Space.World),
		new LuaEnum("Self", Space.Self),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Space", enums);
		LuaScriptMgr.RegisterFunc(L, "Space", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Space o = (Space)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

