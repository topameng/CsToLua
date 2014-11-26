using UnityEngine;
using System;
using LuaInterface;

public class SpriteAlignmentWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Center", SpriteAlignment.Center),
		new LuaEnum("TopLeft", SpriteAlignment.TopLeft),
		new LuaEnum("TopCenter", SpriteAlignment.TopCenter),
		new LuaEnum("TopRight", SpriteAlignment.TopRight),
		new LuaEnum("LeftCenter", SpriteAlignment.LeftCenter),
		new LuaEnum("RightCenter", SpriteAlignment.RightCenter),
		new LuaEnum("BottomLeft", SpriteAlignment.BottomLeft),
		new LuaEnum("BottomCenter", SpriteAlignment.BottomCenter),
		new LuaEnum("BottomRight", SpriteAlignment.BottomRight),
		new LuaEnum("Custom", SpriteAlignment.Custom),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SpriteAlignment", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.SpriteAlignment", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		SpriteAlignment o = (SpriteAlignment)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

