using UnityEngine;
using System;
using LuaInterface;

public class MatchTargetWeightMaskWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateMatchTargetWeightMask),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("positionXYZWeight", get_positionXYZWeight, set_positionXYZWeight),
		new LuaField("rotationWeight", get_rotationWeight, set_rotationWeight),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMatchTargetWeightMask(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			MatchTargetWeightMask obj = new MatchTargetWeightMask(arg0,arg1);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			MatchTargetWeightMask obj = new MatchTargetWeightMask();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MatchTargetWeightMask.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(MatchTargetWeightMask));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.MatchTargetWeightMask", typeof(MatchTargetWeightMask), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_positionXYZWeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positionXYZWeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positionXYZWeight on a nil value");
			}
		}

		MatchTargetWeightMask obj = (MatchTargetWeightMask)o;
		LuaScriptMgr.PushValue(L, obj.positionXYZWeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationWeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationWeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationWeight on a nil value");
			}
		}

		MatchTargetWeightMask obj = (MatchTargetWeightMask)o;
		LuaScriptMgr.Push(L, obj.rotationWeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_positionXYZWeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positionXYZWeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positionXYZWeight on a nil value");
			}
		}

		MatchTargetWeightMask obj = (MatchTargetWeightMask)o;
		obj.positionXYZWeight = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotationWeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationWeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationWeight on a nil value");
			}
		}

		MatchTargetWeightMask obj = (MatchTargetWeightMask)o;
		obj.rotationWeight = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

