using UnityEngine;
using System;
using LuaInterface;

public class ProceduralLoadingBehaviorWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("DoNothing", ProceduralLoadingBehavior.DoNothing),
		new LuaEnum("Generate", ProceduralLoadingBehavior.Generate),
		new LuaEnum("BakeAndKeep", ProceduralLoadingBehavior.BakeAndKeep),
		new LuaEnum("BakeAndDiscard", ProceduralLoadingBehavior.BakeAndDiscard),
		new LuaEnum("Cache", ProceduralLoadingBehavior.Cache),
		new LuaEnum("DoNothingAndCache", ProceduralLoadingBehavior.DoNothingAndCache),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ProceduralLoadingBehavior", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ProceduralLoadingBehavior", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ProceduralLoadingBehavior o = (ProceduralLoadingBehavior)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

