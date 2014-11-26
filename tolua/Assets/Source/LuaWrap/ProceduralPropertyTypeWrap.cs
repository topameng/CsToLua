using UnityEngine;
using System;
using LuaInterface;

public class ProceduralPropertyTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Boolean", ProceduralPropertyType.Boolean),
		new LuaEnum("Float", ProceduralPropertyType.Float),
		new LuaEnum("Vector2", ProceduralPropertyType.Vector2),
		new LuaEnum("Vector3", ProceduralPropertyType.Vector3),
		new LuaEnum("Vector4", ProceduralPropertyType.Vector4),
		new LuaEnum("Color3", ProceduralPropertyType.Color3),
		new LuaEnum("Color4", ProceduralPropertyType.Color4),
		new LuaEnum("Enum", ProceduralPropertyType.Enum),
		new LuaEnum("Texture", ProceduralPropertyType.Texture),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ProceduralPropertyType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ProceduralPropertyType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ProceduralPropertyType o = (ProceduralPropertyType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

