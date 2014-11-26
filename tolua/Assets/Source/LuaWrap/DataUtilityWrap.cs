using UnityEngine;
using System;
using UnityEngine.Sprites;
using LuaInterface;

public class DataUtilityWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetInnerUV", GetInnerUV),
		new LuaMethod("GetOuterUV", GetOuterUV),
		new LuaMethod("GetPadding", GetPadding),
		new LuaMethod("GetMinSize", GetMinSize),
		new LuaMethod("New", _CreateDataUtility),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDataUtility(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			DataUtility obj = new DataUtility();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: DataUtility.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(DataUtility));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Sprites.DataUtility", typeof(DataUtility), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInnerUV(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Sprite arg0 = LuaScriptMgr.GetNetObject<Sprite>(L, 1);
		Vector4 o = DataUtility.GetInnerUV(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOuterUV(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Sprite arg0 = LuaScriptMgr.GetNetObject<Sprite>(L, 1);
		Vector4 o = DataUtility.GetOuterUV(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPadding(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Sprite arg0 = LuaScriptMgr.GetNetObject<Sprite>(L, 1);
		Vector4 o = DataUtility.GetPadding(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMinSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Sprite arg0 = LuaScriptMgr.GetNetObject<Sprite>(L, 1);
		Vector2 o = DataUtility.GetMinSize(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}
}

