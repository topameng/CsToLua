using System;
using LuaInterface;

public class TestOverride_SpaceWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("World", GetWorld),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "TestOverride.Space", typeof(TestOverride.Space), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWorld(IntPtr L)
	{
		LuaScriptMgr.Push(L, TestOverride.Space.World);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TestOverride.Space o = (TestOverride.Space)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

