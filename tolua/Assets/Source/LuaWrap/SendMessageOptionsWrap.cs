using UnityEngine;
using System;
using LuaInterface;

public class SendMessageOptionsWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("RequireReceiver", SendMessageOptions.RequireReceiver),
		new LuaEnum("DontRequireReceiver", SendMessageOptions.DontRequireReceiver),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SendMessageOptions", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.SendMessageOptions", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		SendMessageOptions o = (SendMessageOptions)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

