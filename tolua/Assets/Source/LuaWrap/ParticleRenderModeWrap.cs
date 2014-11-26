using UnityEngine;
using System;
using LuaInterface;

public class ParticleRenderModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Billboard", ParticleRenderMode.Billboard),
		new LuaEnum("Stretch", ParticleRenderMode.Stretch),
		new LuaEnum("SortedBillboard", ParticleRenderMode.SortedBillboard),
		new LuaEnum("HorizontalBillboard", ParticleRenderMode.HorizontalBillboard),
		new LuaEnum("VerticalBillboard", ParticleRenderMode.VerticalBillboard),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleRenderMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ParticleRenderMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ParticleRenderMode o = (ParticleRenderMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

