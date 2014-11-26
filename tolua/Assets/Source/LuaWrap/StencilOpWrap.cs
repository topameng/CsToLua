using UnityEngine;
using System;
using UnityEngine.Rendering;
using LuaInterface;

public class StencilOpWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Keep", StencilOp.Keep),
		new LuaEnum("Zero", StencilOp.Zero),
		new LuaEnum("Replace", StencilOp.Replace),
		new LuaEnum("IncrementSaturate", StencilOp.IncrementSaturate),
		new LuaEnum("DecrementSaturate", StencilOp.DecrementSaturate),
		new LuaEnum("Invert", StencilOp.Invert),
		new LuaEnum("IncrementWrap", StencilOp.IncrementWrap),
		new LuaEnum("DecrementWrap", StencilOp.DecrementWrap),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Rendering.StencilOp", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.Rendering.StencilOp", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		StencilOp o = (StencilOp)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

