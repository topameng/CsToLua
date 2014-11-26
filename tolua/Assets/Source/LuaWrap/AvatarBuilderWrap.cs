using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class AvatarBuilderWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("BuildHumanAvatar", BuildHumanAvatar),
		new LuaMethod("BuildGenericAvatar", BuildGenericAvatar),
		new LuaMethod("New", _CreateAvatarBuilder),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAvatarBuilder(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AvatarBuilder obj = new AvatarBuilder();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AvatarBuilder.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AvatarBuilder));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AvatarBuilder", typeof(AvatarBuilder), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BuildHumanAvatar(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		HumanDescription arg1 = LuaScriptMgr.GetNetObject<HumanDescription>(L, 2);
		Avatar o = AvatarBuilder.BuildHumanAvatar(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BuildGenericAvatar(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Avatar o = AvatarBuilder.BuildGenericAvatar(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

