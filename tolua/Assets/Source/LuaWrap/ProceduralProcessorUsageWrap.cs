using UnityEngine;
using System;
using LuaInterface;

public class ProceduralProcessorUsageWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Unsupported", ProceduralProcessorUsage.Unsupported),
		new LuaEnum("One", ProceduralProcessorUsage.One),
		new LuaEnum("Half", ProceduralProcessorUsage.Half),
		new LuaEnum("All", ProceduralProcessorUsage.All),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ProceduralProcessorUsage", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ProceduralProcessorUsage", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ProceduralProcessorUsage o = (ProceduralProcessorUsage)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

