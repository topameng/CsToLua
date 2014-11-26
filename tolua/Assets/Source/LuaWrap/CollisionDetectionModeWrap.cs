using UnityEngine;
using System;
using LuaInterface;

public class CollisionDetectionModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Discrete", CollisionDetectionMode.Discrete),
		new LuaEnum("Continuous", CollisionDetectionMode.Continuous),
		new LuaEnum("ContinuousDynamic", CollisionDetectionMode.ContinuousDynamic),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.CollisionDetectionMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.CollisionDetectionMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CollisionDetectionMode o = (CollisionDetectionMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

