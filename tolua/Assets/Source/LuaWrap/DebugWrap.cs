using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class DebugWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("DrawLine", DrawLine),
		new LuaMethod("DrawRay", DrawRay),
		new LuaMethod("Break", Break),
		new LuaMethod("DebugBreak", DebugBreak),
		new LuaMethod("Log", Log),
		new LuaMethod("LogError", LogError),
		new LuaMethod("ClearDeveloperConsole", ClearDeveloperConsole),
		new LuaMethod("LogException", LogException),
		new LuaMethod("LogWarning", LogWarning),
		new LuaMethod("New", _CreateDebug),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("developerConsoleVisible", get_developerConsoleVisible, set_developerConsoleVisible),
		new LuaField("isDebugBuild", get_isDebugBuild, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDebug(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Debug obj = new Debug();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Debug));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Debug", typeof(Debug), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_developerConsoleVisible(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debug.developerConsoleVisible);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isDebugBuild(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debug.isDebugBuild);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_developerConsoleVisible(IntPtr L)
	{
		Debug.developerConsoleVisible = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawLine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Debug.DrawLine(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Color arg2 = LuaScriptMgr.GetNetObject<Color>(L, 3);
			Debug.DrawLine(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Color arg2 = LuaScriptMgr.GetNetObject<Color>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Debug.DrawLine(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 5)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Color arg2 = LuaScriptMgr.GetNetObject<Color>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			Debug.DrawLine(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.DrawLine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawRay(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Debug.DrawRay(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Color arg2 = LuaScriptMgr.GetNetObject<Color>(L, 3);
			Debug.DrawRay(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Color arg2 = LuaScriptMgr.GetNetObject<Color>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Debug.DrawRay(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 5)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Color arg2 = LuaScriptMgr.GetNetObject<Color>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			Debug.DrawRay(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.DrawRay");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Break(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Debug.Break();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DebugBreak(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Debug.DebugBreak();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Log(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Debug.Log(arg0);
			return 0;
		}
		else if (count == 2)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Object arg1 = LuaScriptMgr.GetNetObject<Object>(L, 2);
			Debug.Log(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.Log");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogError(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Debug.LogError(arg0);
			return 0;
		}
		else if (count == 2)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Object arg1 = LuaScriptMgr.GetNetObject<Object>(L, 2);
			Debug.LogError(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogError");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearDeveloperConsole(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Debug.ClearDeveloperConsole();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogException(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Exception arg0 = LuaScriptMgr.GetNetObject<Exception>(L, 1);
			Debug.LogException(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Exception arg0 = LuaScriptMgr.GetNetObject<Exception>(L, 1);
			Object arg1 = LuaScriptMgr.GetNetObject<Object>(L, 2);
			Debug.LogException(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogException");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWarning(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Debug.LogWarning(arg0);
			return 0;
		}
		else if (count == 2)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Object arg1 = LuaScriptMgr.GetNetObject<Object>(L, 2);
			Debug.LogWarning(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogWarning");
		}

		return 0;
	}
}

