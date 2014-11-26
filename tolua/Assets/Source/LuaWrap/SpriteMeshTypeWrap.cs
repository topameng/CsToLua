using UnityEngine;
using System;
using LuaInterface;

public class SpriteMeshTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("FullRect", SpriteMeshType.FullRect),
		new LuaEnum("Tight", SpriteMeshType.Tight),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SpriteMeshType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.SpriteMeshType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		SpriteMeshType o = (SpriteMeshType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

