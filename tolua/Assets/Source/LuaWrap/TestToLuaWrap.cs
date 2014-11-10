using System;
using UnityEngine;
using LuaInterface;

public class TestToLuaWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Test", Test),
		new LuaMethod("Empty", Empty),
		new LuaMethod("TestDef", TestDef),
		new LuaMethod("Test2", Test2),
		new LuaMethod("Test3", Test3),
		new LuaMethod("Test4", Test4),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckParamsType(L, typeof(object), 1, count))
		{
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
			TestToLua obj = new TestToLua(objs0);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			TestToLua obj = new TestToLua();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: TestToLua.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(TestToLua));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "TestToLua", typeof(TestToLua), regs, fields, "object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Test(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		TestToLua obj = LuaScriptMgr.GetNetObject<TestToLua>(L, 1);
		int arg0 = LuaScriptMgr.GetNetObject<int>(L, 2);
		int arg1 = LuaScriptMgr.GetNetObject<int>(L, 3);
		int o = obj.Test(ref arg0,ref arg1);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.Push(L, arg0);
		LuaScriptMgr.Push(L, arg1);
		return 3;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Empty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		TestToLua obj = LuaScriptMgr.GetNetObject<TestToLua>(L, 1);
		Func<int,int,int,string> arg0 = LuaScriptMgr.GetNetObject<Func<int,int,int,string>>(L, 2);
		obj.Empty(arg0);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TestDef(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		TestToLua obj = LuaScriptMgr.GetNetObject<TestToLua>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.TestDef(arg0,arg1);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Test2(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		TestToLua obj = LuaScriptMgr.GetNetObject<TestToLua>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		obj.Test2(arg0,objs1);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Test3(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		TestToLua obj = LuaScriptMgr.GetNetObject<TestToLua>(L, 1);
		GameObject[] objs0 = LuaScriptMgr.GetParamsObject<GameObject>(L, 2, count - 1);
		obj.Test3(objs0);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Test4(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		TestToLua obj = LuaScriptMgr.GetNetObject<TestToLua>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		obj.Test4(arg0,arg1,arg2);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

