using UnityEngine;
using System;
using LuaInterface;

public class RigidbodyConstraintsWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", RigidbodyConstraints.None),
		new LuaEnum("FreezePositionX", RigidbodyConstraints.FreezePositionX),
		new LuaEnum("FreezePositionY", RigidbodyConstraints.FreezePositionY),
		new LuaEnum("FreezePositionZ", RigidbodyConstraints.FreezePositionZ),
		new LuaEnum("FreezeRotationX", RigidbodyConstraints.FreezeRotationX),
		new LuaEnum("FreezeRotationY", RigidbodyConstraints.FreezeRotationY),
		new LuaEnum("FreezeRotationZ", RigidbodyConstraints.FreezeRotationZ),
		new LuaEnum("FreezePosition", RigidbodyConstraints.FreezePosition),
		new LuaEnum("FreezeRotation", RigidbodyConstraints.FreezeRotation),
		new LuaEnum("FreezeAll", RigidbodyConstraints.FreezeAll),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RigidbodyConstraints", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RigidbodyConstraints", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RigidbodyConstraints o = (RigidbodyConstraints)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

