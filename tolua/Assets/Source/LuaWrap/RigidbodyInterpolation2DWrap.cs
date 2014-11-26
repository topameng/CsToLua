using UnityEngine;
using System;
using LuaInterface;

public class RigidbodyInterpolation2DWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", RigidbodyInterpolation2D.None),
		new LuaEnum("Interpolate", RigidbodyInterpolation2D.Interpolate),
		new LuaEnum("Extrapolate", RigidbodyInterpolation2D.Extrapolate),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RigidbodyInterpolation2D", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RigidbodyInterpolation2D", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RigidbodyInterpolation2D o = (RigidbodyInterpolation2D)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

