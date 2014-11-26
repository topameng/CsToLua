using UnityEngine;
using System;
using UnityEngine.Rendering;
using LuaInterface;

public class CullModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Off", CullMode.Off),
		new LuaEnum("Front", CullMode.Front),
		new LuaEnum("Back", CullMode.Back),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Rendering.CullMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.Rendering.CullMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CullMode o = (CullMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

