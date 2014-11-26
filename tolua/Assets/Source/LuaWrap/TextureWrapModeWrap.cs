using UnityEngine;
using System;
using LuaInterface;

public class TextureWrapModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Repeat", TextureWrapMode.Repeat),
		new LuaEnum("Clamp", TextureWrapMode.Clamp),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TextureWrapMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.TextureWrapMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TextureWrapMode o = (TextureWrapMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

