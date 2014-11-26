using UnityEngine;
using System;
using LuaInterface;

public class ProceduralCacheSizeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Tiny", ProceduralCacheSize.Tiny),
		new LuaEnum("Medium", ProceduralCacheSize.Medium),
		new LuaEnum("Heavy", ProceduralCacheSize.Heavy),
		new LuaEnum("NoLimit", ProceduralCacheSize.NoLimit),
		new LuaEnum("None", ProceduralCacheSize.None),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ProceduralCacheSize", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ProceduralCacheSize", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ProceduralCacheSize o = (ProceduralCacheSize)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

