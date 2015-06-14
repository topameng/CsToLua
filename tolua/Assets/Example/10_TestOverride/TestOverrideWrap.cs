using System;
using LuaInterface;

public class TestOverrideWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Test", Test),
			new LuaMethod("New", _CreateTestOverride),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "TestOverride", typeof(TestOverride), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTestOverride(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			TestOverride obj = new TestOverride();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: TestOverride.New");
		}

		return 0;
	}

	static Type classType = typeof(TestOverride);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Test(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(TestOverride), typeof(string)))
		{
			TestOverride obj = (TestOverride)LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int o = obj.Test(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			int o = TestOverride.Test(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(TestOverride), typeof(TestOverride.Space)))
		{
			TestOverride obj = (TestOverride)LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride");
			TestOverride.Space arg0 = (TestOverride.Space)LuaScriptMgr.GetLuaObject(L, 2);
			int o = obj.Test(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(TestOverride), typeof(double)))
		{
			TestOverride obj = (TestOverride)LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride");
			double arg0 = (double)LuaDLL.lua_tonumber(L, 2);
			int o = obj.Test(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(TestOverride), typeof(object)))
		{
			TestOverride obj = (TestOverride)LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			int o = obj.Test(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(TestOverride), typeof(int), typeof(int)))
		{
			TestOverride obj = (TestOverride)LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int o = obj.Test(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(TestOverride), typeof(object), typeof(string)))
		{
			TestOverride obj = (TestOverride)LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			string arg1 = LuaScriptMgr.GetString(L, 3);
			int o = obj.Test(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			TestOverride obj = (TestOverride)LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride");
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			int o = obj.Test(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: TestOverride.Test");
		}

		return 0;
	}
}

