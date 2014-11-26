using UnityEngine;
using System;
using LuaInterface;

public class ParticleSystemSimulationSpaceWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Local", ParticleSystemSimulationSpace.Local),
		new LuaEnum("World", ParticleSystemSimulationSpace.World),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleSystemSimulationSpace", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ParticleSystemSimulationSpace", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ParticleSystemSimulationSpace o = (ParticleSystemSimulationSpace)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

