using UnityEngine;
using System;
using LuaInterface;

public class RenderTextureReadWriteWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Default", RenderTextureReadWrite.Default),
		new LuaEnum("Linear", RenderTextureReadWrite.Linear),
		new LuaEnum("sRGB", RenderTextureReadWrite.sRGB),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RenderTextureReadWrite", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RenderTextureReadWrite", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RenderTextureReadWrite o = (RenderTextureReadWrite)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

