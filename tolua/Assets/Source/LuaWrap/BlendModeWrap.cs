using UnityEngine;
using System;
using UnityEngine.Rendering;
using LuaInterface;

public class BlendModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Zero", BlendMode.Zero),
		new LuaEnum("One", BlendMode.One),
		new LuaEnum("DstColor", BlendMode.DstColor),
		new LuaEnum("SrcColor", BlendMode.SrcColor),
		new LuaEnum("OneMinusDstColor", BlendMode.OneMinusDstColor),
		new LuaEnum("SrcAlpha", BlendMode.SrcAlpha),
		new LuaEnum("OneMinusSrcColor", BlendMode.OneMinusSrcColor),
		new LuaEnum("DstAlpha", BlendMode.DstAlpha),
		new LuaEnum("OneMinusDstAlpha", BlendMode.OneMinusDstAlpha),
		new LuaEnum("SrcAlphaSaturate", BlendMode.SrcAlphaSaturate),
		new LuaEnum("OneMinusSrcAlpha", BlendMode.OneMinusSrcAlpha),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Rendering.BlendMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.Rendering.BlendMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		BlendMode o = (BlendMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

