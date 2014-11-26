using UnityEngine;
using System;
using LuaInterface;

public class ImagePositionWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("ImageLeft", ImagePosition.ImageLeft),
		new LuaEnum("ImageAbove", ImagePosition.ImageAbove),
		new LuaEnum("ImageOnly", ImagePosition.ImageOnly),
		new LuaEnum("TextOnly", ImagePosition.TextOnly),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ImagePosition", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ImagePosition", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ImagePosition o = (ImagePosition)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

