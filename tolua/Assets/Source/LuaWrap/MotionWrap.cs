using UnityEngine;
using System;
using LuaInterface;

public class MotionWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("ValidateIfRetargetable", ValidateIfRetargetable),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("averageDuration", get_averageDuration, null),
		new LuaField("averageAngularSpeed", get_averageAngularSpeed, null),
		new LuaField("averageSpeed", get_averageSpeed, null),
		new LuaField("apparentSpeed", get_apparentSpeed, null),
		new LuaField("isLooping", get_isLooping, null),
		new LuaField("isAnimatorMotion", get_isAnimatorMotion, null),
		new LuaField("isHumanMotion", get_isHumanMotion, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Motion obj = new Motion();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Motion.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Motion));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Motion", typeof(Motion), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_averageDuration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name averageDuration");
		}

		Motion obj = (Motion)o;
		LuaScriptMgr.Push(L, obj.averageDuration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_averageAngularSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name averageAngularSpeed");
		}

		Motion obj = (Motion)o;
		LuaScriptMgr.Push(L, obj.averageAngularSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_averageSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name averageSpeed");
		}

		Motion obj = (Motion)o;
		LuaScriptMgr.PushValue(L, obj.averageSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_apparentSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name apparentSpeed");
		}

		Motion obj = (Motion)o;
		LuaScriptMgr.Push(L, obj.apparentSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isLooping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name isLooping");
		}

		Motion obj = (Motion)o;
		LuaScriptMgr.Push(L, obj.isLooping);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isAnimatorMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name isAnimatorMotion");
		}

		Motion obj = (Motion)o;
		LuaScriptMgr.Push(L, obj.isAnimatorMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isHumanMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name isHumanMotion");
		}

		Motion obj = (Motion)o;
		LuaScriptMgr.Push(L, obj.isHumanMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ValidateIfRetargetable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Motion obj = LuaScriptMgr.GetNetObject<Motion>(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		bool o = obj.ValidateIfRetargetable(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

