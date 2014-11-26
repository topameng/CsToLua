using UnityEngine;
using System;
using LuaInterface;

public class UserAuthorizationWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("WebCam", UserAuthorization.WebCam),
		new LuaEnum("Microphone", UserAuthorization.Microphone),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.UserAuthorization", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.UserAuthorization", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		UserAuthorization o = (UserAuthorization)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

