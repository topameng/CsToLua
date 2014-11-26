using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ScriptableObjectWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("CreateInstance", CreateInstance),
		new LuaMethod("New", _CreateScriptableObject),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateScriptableObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ScriptableObject obj = new ScriptableObject();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ScriptableObject.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ScriptableObject));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ScriptableObject", typeof(ScriptableObject), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateInstance(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Type)};
		Type[] types1 = {typeof(string)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			ScriptableObject o = ScriptableObject.CreateInstance(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			ScriptableObject o = ScriptableObject.CreateInstance(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ScriptableObject.CreateInstance");
		}

		return 0;
	}
}

