using UnityEngine;
using System;
using LuaInterface;

public class NavMeshPathStatusWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("PathComplete", NavMeshPathStatus.PathComplete),
		new LuaEnum("PathPartial", NavMeshPathStatus.PathPartial),
		new LuaEnum("PathInvalid", NavMeshPathStatus.PathInvalid),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.NavMeshPathStatus", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.NavMeshPathStatus", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		NavMeshPathStatus o = (NavMeshPathStatus)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

