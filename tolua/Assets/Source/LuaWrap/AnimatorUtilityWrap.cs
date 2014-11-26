using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class AnimatorUtilityWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OptimizeTransformHierarchy", OptimizeTransformHierarchy),
		new LuaMethod("DeoptimizeTransformHierarchy", DeoptimizeTransformHierarchy),
		new LuaMethod("New", _CreateAnimatorUtility),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnimatorUtility(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AnimatorUtility obj = new AnimatorUtility();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimatorUtility.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AnimatorUtility));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimatorUtility", typeof(AnimatorUtility), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OptimizeTransformHierarchy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
		AnimatorUtility.OptimizeTransformHierarchy(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DeoptimizeTransformHierarchy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		AnimatorUtility.DeoptimizeTransformHierarchy(arg0);
		return 0;
	}
}

