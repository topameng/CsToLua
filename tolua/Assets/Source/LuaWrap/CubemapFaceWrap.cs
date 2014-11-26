using UnityEngine;
using System;
using LuaInterface;

public class CubemapFaceWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("PositiveX", CubemapFace.PositiveX),
		new LuaEnum("NegativeX", CubemapFace.NegativeX),
		new LuaEnum("PositiveY", CubemapFace.PositiveY),
		new LuaEnum("NegativeY", CubemapFace.NegativeY),
		new LuaEnum("PositiveZ", CubemapFace.PositiveZ),
		new LuaEnum("NegativeZ", CubemapFace.NegativeZ),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.CubemapFace", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.CubemapFace", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CubemapFace o = (CubemapFace)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

