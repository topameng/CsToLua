using UnityEngine;
using System;
using LuaInterface;

public class CameraClearFlagsWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Skybox", CameraClearFlags.Skybox),
		new LuaEnum("Color", CameraClearFlags.Color),
		new LuaEnum("SolidColor", CameraClearFlags.SolidColor),
		new LuaEnum("Depth", CameraClearFlags.Depth),
		new LuaEnum("Nothing", CameraClearFlags.Nothing),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.CameraClearFlags", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.CameraClearFlags", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CameraClearFlags o = (CameraClearFlags)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

