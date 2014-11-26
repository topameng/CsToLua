using System;
using UnityEngineInternal;
using LuaInterface;

public class ReproductionWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("CaptureScreenshot", CaptureScreenshot),
		new LuaMethod("New", _CreateReproduction),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateReproduction(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Reproduction obj = new Reproduction();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Reproduction.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Reproduction));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngineInternal.Reproduction", typeof(Reproduction), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CaptureScreenshot(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Reproduction.CaptureScreenshot();
		return 0;
	}
}

