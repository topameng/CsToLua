using UnityEngine;
using System;
using LuaInterface;

public class QueueModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("CompleteOthers", QueueMode.CompleteOthers),
		new LuaEnum("PlayNow", QueueMode.PlayNow),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.QueueMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.QueueMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		QueueMode o = (QueueMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

