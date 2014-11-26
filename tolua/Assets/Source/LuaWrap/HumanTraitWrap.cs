using UnityEngine;
using System;
using LuaInterface;

public class HumanTraitWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("MuscleFromBone", MuscleFromBone),
		new LuaMethod("BoneFromMuscle", BoneFromMuscle),
		new LuaMethod("RequiredBone", RequiredBone),
		new LuaMethod("GetMuscleDefaultMin", GetMuscleDefaultMin),
		new LuaMethod("GetMuscleDefaultMax", GetMuscleDefaultMax),
		new LuaMethod("New", _CreateHumanTrait),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("MuscleCount", get_MuscleCount, null),
		new LuaField("MuscleName", get_MuscleName, null),
		new LuaField("BoneCount", get_BoneCount, null),
		new LuaField("BoneName", get_BoneName, null),
		new LuaField("RequiredBoneCount", get_RequiredBoneCount, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateHumanTrait(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			HumanTrait obj = new HumanTrait();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: HumanTrait.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(HumanTrait));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.HumanTrait", typeof(HumanTrait), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MuscleCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, HumanTrait.MuscleCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MuscleName(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, HumanTrait.MuscleName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BoneCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, HumanTrait.BoneCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BoneName(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, HumanTrait.BoneName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_RequiredBoneCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, HumanTrait.RequiredBoneCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MuscleFromBone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = HumanTrait.MuscleFromBone(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BoneFromMuscle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int o = HumanTrait.BoneFromMuscle(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RequiredBone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		bool o = HumanTrait.RequiredBone(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMuscleDefaultMin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		float o = HumanTrait.GetMuscleDefaultMin(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMuscleDefaultMax(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		float o = HumanTrait.GetMuscleDefaultMax(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

