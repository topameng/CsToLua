using UnityEngine;
using System;
using LuaInterface;

public class NPOTSupportWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", NPOTSupport.None),
		new LuaEnum("Restricted", NPOTSupport.Restricted),
		new LuaEnum("Full", NPOTSupport.Full),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.NPOTSupport", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.NPOTSupport", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		NPOTSupport o = (NPOTSupport)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

