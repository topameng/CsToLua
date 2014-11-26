using UnityEngine;
using System;
using LuaInterface;

public class HideFlagsWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", HideFlags.None),
		new LuaEnum("HideInHierarchy", HideFlags.HideInHierarchy),
		new LuaEnum("HideInInspector", HideFlags.HideInInspector),
		new LuaEnum("DontSave", HideFlags.DontSave),
		new LuaEnum("NotEditable", HideFlags.NotEditable),
		new LuaEnum("HideAndDontSave", HideFlags.HideAndDontSave),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.HideFlags", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.HideFlags", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		HideFlags o = (HideFlags)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

