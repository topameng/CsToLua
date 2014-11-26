using UnityEngine;
using System;
using LuaInterface;

public class RenderTextureFormatWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("ARGB32", RenderTextureFormat.ARGB32),
		new LuaEnum("Depth", RenderTextureFormat.Depth),
		new LuaEnum("ARGBHalf", RenderTextureFormat.ARGBHalf),
		new LuaEnum("RGB565", RenderTextureFormat.RGB565),
		new LuaEnum("ARGB4444", RenderTextureFormat.ARGB4444),
		new LuaEnum("ARGB1555", RenderTextureFormat.ARGB1555),
		new LuaEnum("Default", RenderTextureFormat.Default),
		new LuaEnum("DefaultHDR", RenderTextureFormat.DefaultHDR),
		new LuaEnum("ARGBFloat", RenderTextureFormat.ARGBFloat),
		new LuaEnum("RGFloat", RenderTextureFormat.RGFloat),
		new LuaEnum("RGHalf", RenderTextureFormat.RGHalf),
		new LuaEnum("RFloat", RenderTextureFormat.RFloat),
		new LuaEnum("RHalf", RenderTextureFormat.RHalf),
		new LuaEnum("R8", RenderTextureFormat.R8),
		new LuaEnum("ARGBInt", RenderTextureFormat.ARGBInt),
		new LuaEnum("RGInt", RenderTextureFormat.RGInt),
		new LuaEnum("RInt", RenderTextureFormat.RInt),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RenderTextureFormat", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RenderTextureFormat", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RenderTextureFormat o = (RenderTextureFormat)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

