using UnityEngine;
using System;
using LuaInterface;

public class WebCamFlagsWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("FrontFacing", WebCamFlags.FrontFacing),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.WebCamFlags", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.WebCamFlags", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		WebCamFlags o = (WebCamFlags)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

