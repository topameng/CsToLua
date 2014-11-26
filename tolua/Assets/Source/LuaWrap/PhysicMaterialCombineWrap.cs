using UnityEngine;
using System;
using LuaInterface;

public class PhysicMaterialCombineWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Average", PhysicMaterialCombine.Average),
		new LuaEnum("Minimum", PhysicMaterialCombine.Minimum),
		new LuaEnum("Multiply", PhysicMaterialCombine.Multiply),
		new LuaEnum("Maximum", PhysicMaterialCombine.Maximum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.PhysicMaterialCombine", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.PhysicMaterialCombine", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		PhysicMaterialCombine o = (PhysicMaterialCombine)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

