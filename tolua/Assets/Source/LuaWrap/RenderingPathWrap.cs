using UnityEngine;
using System;
using LuaInterface;

public class RenderingPathWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("UsePlayerSettings", RenderingPath.UsePlayerSettings),
		new LuaEnum("VertexLit", RenderingPath.VertexLit),
		new LuaEnum("Forward", RenderingPath.Forward),
		new LuaEnum("DeferredLighting", RenderingPath.DeferredLighting),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RenderingPath", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RenderingPath", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RenderingPath o = (RenderingPath)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

