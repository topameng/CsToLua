using UnityEngine;
using System;
using LuaInterface;

public class BoneWeightWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Equals", Equals),
		new LuaMethod("New", _CreateBoneWeight),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("weight0", get_weight0, set_weight0),
		new LuaField("weight1", get_weight1, set_weight1),
		new LuaField("weight2", get_weight2, set_weight2),
		new LuaField("weight3", get_weight3, set_weight3),
		new LuaField("boneIndex0", get_boneIndex0, set_boneIndex0),
		new LuaField("boneIndex1", get_boneIndex1, set_boneIndex1),
		new LuaField("boneIndex2", get_boneIndex2, set_boneIndex2),
		new LuaField("boneIndex3", get_boneIndex3, set_boneIndex3),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateBoneWeight(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		BoneWeight obj = new BoneWeight();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(BoneWeight));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.BoneWeight", typeof(BoneWeight), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_weight0(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weight0");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weight0 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		LuaScriptMgr.Push(L, obj.weight0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_weight1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weight1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weight1 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		LuaScriptMgr.Push(L, obj.weight1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_weight2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weight2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weight2 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		LuaScriptMgr.Push(L, obj.weight2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_weight3(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weight3");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weight3 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		LuaScriptMgr.Push(L, obj.weight3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_boneIndex0(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneIndex0");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneIndex0 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		LuaScriptMgr.Push(L, obj.boneIndex0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_boneIndex1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneIndex1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneIndex1 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		LuaScriptMgr.Push(L, obj.boneIndex1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_boneIndex2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneIndex2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneIndex2 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		LuaScriptMgr.Push(L, obj.boneIndex2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_boneIndex3(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneIndex3");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneIndex3 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		LuaScriptMgr.Push(L, obj.boneIndex3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_weight0(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weight0");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weight0 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		obj.weight0 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_weight1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weight1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weight1 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		obj.weight1 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_weight2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weight2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weight2 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		obj.weight2 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_weight3(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weight3");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weight3 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		obj.weight3 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_boneIndex0(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneIndex0");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneIndex0 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		obj.boneIndex0 = (int)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_boneIndex1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneIndex1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneIndex1 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		obj.boneIndex1 = (int)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_boneIndex2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneIndex2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneIndex2 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		obj.boneIndex2 = (int)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_boneIndex3(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneIndex3");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneIndex3 on a nil value");
			}
		}

		BoneWeight obj = (BoneWeight)o;
		obj.boneIndex3 = (int)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BoneWeight obj = LuaScriptMgr.GetNetObject<BoneWeight>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BoneWeight obj = LuaScriptMgr.GetNetObject<BoneWeight>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BoneWeight arg0 = LuaScriptMgr.GetNetObject<BoneWeight>(L, 1);
		BoneWeight arg1 = LuaScriptMgr.GetNetObject<BoneWeight>(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

