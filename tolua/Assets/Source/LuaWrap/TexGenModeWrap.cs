using UnityEngine;
using System;
using LuaInterface;

public class TexGenModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", TexGenMode.None),
		new LuaEnum("SphereMap", TexGenMode.SphereMap),
		new LuaEnum("Object", TexGenMode.Object),
		new LuaEnum("EyeLinear", TexGenMode.EyeLinear),
		new LuaEnum("CubeReflect", TexGenMode.CubeReflect),
		new LuaEnum("CubeNormal", TexGenMode.CubeNormal),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TexGenMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.TexGenMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TexGenMode o = (TexGenMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

