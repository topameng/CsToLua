using UnityEngine;
using System;
using LuaInterface;

public class SpritePackingRotationWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", SpritePackingRotation.None),
		new LuaEnum("Any", SpritePackingRotation.Any),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SpritePackingRotation", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.SpritePackingRotation", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		SpritePackingRotation o = (SpritePackingRotation)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

