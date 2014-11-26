using UnityEngine;
using System;
using LuaInterface;

public class PrimitiveTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Sphere", PrimitiveType.Sphere),
		new LuaEnum("Capsule", PrimitiveType.Capsule),
		new LuaEnum("Cylinder", PrimitiveType.Cylinder),
		new LuaEnum("Cube", PrimitiveType.Cube),
		new LuaEnum("Plane", PrimitiveType.Plane),
		new LuaEnum("Quad", PrimitiveType.Quad),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.PrimitiveType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.PrimitiveType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		PrimitiveType o = (PrimitiveType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

