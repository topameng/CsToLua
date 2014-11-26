using UnityEngine;
using System;
using LuaInterface;

public class DepthTextureModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", DepthTextureMode.None),
		new LuaEnum("Depth", DepthTextureMode.Depth),
		new LuaEnum("DepthNormals", DepthTextureMode.DepthNormals),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.DepthTextureMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.DepthTextureMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		DepthTextureMode o = (DepthTextureMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

