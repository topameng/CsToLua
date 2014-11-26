using UnityEngine;
using System;
using LuaInterface;

public class RigidbodyInterpolationWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", RigidbodyInterpolation.None),
		new LuaEnum("Interpolate", RigidbodyInterpolation.Interpolate),
		new LuaEnum("Extrapolate", RigidbodyInterpolation.Extrapolate),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RigidbodyInterpolation", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RigidbodyInterpolation", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RigidbodyInterpolation o = (RigidbodyInterpolation)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

