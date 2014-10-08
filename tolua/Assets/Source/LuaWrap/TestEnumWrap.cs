using System;
using LuaInterface;

public class TestEnumWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("One", (int)TestEnum.One),
		new LuaEnum("Two", (int)TestEnum.Two),
		new LuaEnum("Three", (int)TestEnum.Three),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "TestEnum", enums);
	}
}
