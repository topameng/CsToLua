using UnityEngine;
using System;
using LuaInterface;

public class CollisionFlagsWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", CollisionFlags.None),
		new LuaEnum("Sides", CollisionFlags.Sides),
		new LuaEnum("Above", CollisionFlags.Above),
		new LuaEnum("Below", CollisionFlags.Below),
		new LuaEnum("CollidedSides", CollisionFlags.CollidedSides),
		new LuaEnum("CollidedAbove", CollisionFlags.CollidedAbove),
		new LuaEnum("CollidedBelow", CollisionFlags.CollidedBelow),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.CollisionFlags", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.CollisionFlags", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CollisionFlags o = (CollisionFlags)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

