using System;
using LuaInterface;

public class TestProtolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateTestProtol),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("data", get_data, set_data),
		};

		LuaScriptMgr.RegisterLib(L, "TestProtol", typeof(TestProtol), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTestProtol(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TestProtol class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(TestProtol);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_data(IntPtr L)
	{
		LuaScriptMgr.Push(L, TestProtol.data);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_data(IntPtr L)
	{
		TestProtol.data = LuaScriptMgr.GetStringBuffer(L, 3);
		return 0;
	}
}

