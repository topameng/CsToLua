using UnityEngine;
using System;
using LuaInterface;

public class HumanBoneWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateHumanBone),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("limit", get_limit, set_limit),
		new LuaField("boneName", get_boneName, set_boneName),
		new LuaField("humanName", get_humanName, set_humanName),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateHumanBone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		HumanBone obj = new HumanBone();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(HumanBone));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.HumanBone", typeof(HumanBone), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_limit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limit on a nil value");
			}
		}

		HumanBone obj = (HumanBone)o;
		LuaScriptMgr.PushValue(L, obj.limit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_boneName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneName on a nil value");
			}
		}

		HumanBone obj = (HumanBone)o;
		LuaScriptMgr.Push(L, obj.boneName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_humanName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name humanName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index humanName on a nil value");
			}
		}

		HumanBone obj = (HumanBone)o;
		LuaScriptMgr.Push(L, obj.humanName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_limit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limit on a nil value");
			}
		}

		HumanBone obj = (HumanBone)o;
		obj.limit = LuaScriptMgr.GetNetObject<HumanLimit>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_boneName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneName on a nil value");
			}
		}

		HumanBone obj = (HumanBone)o;
		obj.boneName = LuaScriptMgr.GetString(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_humanName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name humanName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index humanName on a nil value");
			}
		}

		HumanBone obj = (HumanBone)o;
		obj.humanName = LuaScriptMgr.GetString(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

