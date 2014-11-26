using UnityEngine;
using System;
using LuaInterface;

public class ComputeBufferTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Default", ComputeBufferType.Default),
		new LuaEnum("Raw", ComputeBufferType.Raw),
		new LuaEnum("Append", ComputeBufferType.Append),
		new LuaEnum("Counter", ComputeBufferType.Counter),
		new LuaEnum("DrawIndirect", ComputeBufferType.DrawIndirect),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ComputeBufferType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ComputeBufferType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ComputeBufferType o = (ComputeBufferType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

