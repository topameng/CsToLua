using System;
using LuaInterface;

public class TestEnumWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("One", TestEnum.One),
		new LuaEnum("Two", TestEnum.Two),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "TestEnum", enums);
		LuaScriptMgr.RegisterFunc(L, "TestEnum", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TestEnum o = (TestEnum)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

