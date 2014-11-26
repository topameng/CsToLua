using UnityEngine;
using System;
using UnityEngine.Rendering;
using LuaInterface;

public class CompareFunctionWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Disabled", CompareFunction.Disabled),
		new LuaEnum("Never", CompareFunction.Never),
		new LuaEnum("Less", CompareFunction.Less),
		new LuaEnum("Equal", CompareFunction.Equal),
		new LuaEnum("LessEqual", CompareFunction.LessEqual),
		new LuaEnum("Greater", CompareFunction.Greater),
		new LuaEnum("NotEqual", CompareFunction.NotEqual),
		new LuaEnum("GreaterEqual", CompareFunction.GreaterEqual),
		new LuaEnum("Always", CompareFunction.Always),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Rendering.CompareFunction", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.Rendering.CompareFunction", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CompareFunction o = (CompareFunction)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

