using UnityEngine;
using System;
using LuaInterface;

public class ImageEffectTransformsToLDRWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateImageEffectTransformsToLDR),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateImageEffectTransformsToLDR(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ImageEffectTransformsToLDR obj = new ImageEffectTransformsToLDR();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ImageEffectTransformsToLDR.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ImageEffectTransformsToLDR));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ImageEffectTransformsToLDR", typeof(ImageEffectTransformsToLDR), regs, fields, "System.Attribute");
	}
}

