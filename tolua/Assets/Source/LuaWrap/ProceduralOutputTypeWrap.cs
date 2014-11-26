using UnityEngine;
using System;
using LuaInterface;

public class ProceduralOutputTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Unknown", ProceduralOutputType.Unknown),
		new LuaEnum("Diffuse", ProceduralOutputType.Diffuse),
		new LuaEnum("Normal", ProceduralOutputType.Normal),
		new LuaEnum("Height", ProceduralOutputType.Height),
		new LuaEnum("Emissive", ProceduralOutputType.Emissive),
		new LuaEnum("Specular", ProceduralOutputType.Specular),
		new LuaEnum("Opacity", ProceduralOutputType.Opacity),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ProceduralOutputType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ProceduralOutputType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ProceduralOutputType o = (ProceduralOutputType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

