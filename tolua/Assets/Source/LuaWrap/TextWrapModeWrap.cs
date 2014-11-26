using UnityEngine;
using System;
using LuaInterface;

public class TextWrapModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Wrap", TextWrapMode.Wrap),
		new LuaEnum("ResizeBounds", TextWrapMode.ResizeBounds),
		new LuaEnum("ShrinkText", TextWrapMode.ShrinkText),
		new LuaEnum("GrowText", TextWrapMode.GrowText),
		new LuaEnum("BestFit", TextWrapMode.BestFit),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TextWrapMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.TextWrapMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TextWrapMode o = (TextWrapMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

