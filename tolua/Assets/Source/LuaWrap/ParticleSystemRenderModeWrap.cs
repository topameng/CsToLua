using UnityEngine;
using System;
using LuaInterface;

public class ParticleSystemRenderModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Billboard", ParticleSystemRenderMode.Billboard),
		new LuaEnum("Stretch", ParticleSystemRenderMode.Stretch),
		new LuaEnum("HorizontalBillboard", ParticleSystemRenderMode.HorizontalBillboard),
		new LuaEnum("VerticalBillboard", ParticleSystemRenderMode.VerticalBillboard),
		new LuaEnum("Mesh", ParticleSystemRenderMode.Mesh),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleSystemRenderMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ParticleSystemRenderMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ParticleSystemRenderMode o = (ParticleSystemRenderMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

