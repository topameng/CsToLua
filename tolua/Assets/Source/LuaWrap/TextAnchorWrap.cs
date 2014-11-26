using UnityEngine;
using System;
using LuaInterface;

public class TextAnchorWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("UpperLeft", TextAnchor.UpperLeft),
		new LuaEnum("UpperCenter", TextAnchor.UpperCenter),
		new LuaEnum("UpperRight", TextAnchor.UpperRight),
		new LuaEnum("MiddleLeft", TextAnchor.MiddleLeft),
		new LuaEnum("MiddleCenter", TextAnchor.MiddleCenter),
		new LuaEnum("MiddleRight", TextAnchor.MiddleRight),
		new LuaEnum("LowerLeft", TextAnchor.LowerLeft),
		new LuaEnum("LowerCenter", TextAnchor.LowerCenter),
		new LuaEnum("LowerRight", TextAnchor.LowerRight),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TextAnchor", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.TextAnchor", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TextAnchor o = (TextAnchor)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

