using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ObjectWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetInstanceID", GetInstanceID),
		new LuaMethod("Instantiate", Instantiate),
		new LuaMethod("Destroy", Destroy),
		new LuaMethod("DestroyImmediate", DestroyImmediate),
		new LuaMethod("FindObjectsOfType", FindObjectsOfType),
		new LuaMethod("FindObjectOfType", FindObjectOfType),
		new LuaMethod("DontDestroyOnLoad", DontDestroyOnLoad),
		new LuaMethod("DestroyObject", DestroyObject),
		new LuaMethod("ToString", ToString),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("name", get_name, set_name),
		new LuaField("hideFlags", get_hideFlags, set_hideFlags),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object obj = null;

		if (count == 0)
		{
			obj = new Object();
			luaMgr.PushResult(obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Object.New' has some invalid arguments");
		}

		return 0;
	}

	public void Register()
	{
		LuaMethod[] metas = new LuaMethod[]
		{
			new LuaMethod("__index", Lua_Index),
			new LuaMethod("__newindex", Lua_NewIndex),
			new LuaMethod("__tostring", Lua_ToString),
			new LuaMethod("__eq", Lua_Eq),
		};

		luaMgr = LuaScriptMgr.Instance;
		reference = luaMgr.RegisterLib("Object", regs);
		luaMgr.CreateMetaTable("Object", metas, typeof(Object));
		luaMgr.RegisterField(typeof(Object), fields);
	}

	static bool get_name(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Object obj = (Object)o;
		luaMgr.PushResult(obj.name);
		return true;
	}

	static bool get_hideFlags(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Object obj = (Object)o;
		luaMgr.PushResult(obj.hideFlags);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return objectWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Object' does not contain a definition for '{0}'", str));
		return 0;
	}

	static bool set_name(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Object obj = (Object)o;
		obj.name = luaMgr.GetString(3);
		return true;
	}

	static bool set_hideFlags(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Object obj = (Object)o;
		obj.hideFlags = (HideFlags)luaMgr.GetNumber(3);
		return true;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return objectWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Object' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr l)
	{
		Object obj = (Object)luaMgr.GetNetObject(1);
		luaMgr.PushResult(obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Object obj = (Object)luaMgr.GetNetObject(1);
		object arg0 = (object)luaMgr.GetNetObject(2);
		bool o = obj.Equals(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Object obj = (Object)luaMgr.GetNetObject(1);
		int o = obj.GetHashCode();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstanceID(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Object obj = (Object)luaMgr.GetNetObject(1);
		int o = obj.GetInstanceID();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Instantiate(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Object arg0 = (Object)luaMgr.GetNetObject(1);
			Object o = Object.Instantiate(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Object arg0 = (Object)luaMgr.GetNetObject(1);
			Vector3 arg1 = (Vector3)luaMgr.GetNetObject(2);
			Quaternion arg2 = (Quaternion)luaMgr.GetNetObject(3);
			Object o = Object.Instantiate(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Object.Instantiate' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Destroy(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Object arg0 = (Object)luaMgr.GetNetObject(1);
			Object.Destroy(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)luaMgr.GetNetObject(1);
			float arg1 = (float)luaMgr.GetNumber(2);
			Object.Destroy(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Object.Destroy' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyImmediate(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Object arg0 = (Object)luaMgr.GetNetObject(1);
			Object.DestroyImmediate(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)luaMgr.GetNetObject(1);
			bool arg1 = luaMgr.GetBoolean(2);
			Object.DestroyImmediate(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Object.DestroyImmediate' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindObjectsOfType(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type arg0 = (Type)luaMgr.GetNetObject(1);
		Object[] o = Object.FindObjectsOfType(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindObjectOfType(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type arg0 = (Type)luaMgr.GetNetObject(1);
		Object o = Object.FindObjectOfType(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DontDestroyOnLoad(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Object arg0 = (Object)luaMgr.GetNetObject(1);
		Object.DontDestroyOnLoad(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyObject(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Object arg0 = (Object)luaMgr.GetNetObject(1);
			Object.DestroyObject(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)luaMgr.GetNetObject(1);
			float arg1 = (float)luaMgr.GetNumber(2);
			Object.DestroyObject(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Object.DestroyObject' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Object obj = (Object)luaMgr.GetNetObject(1);
		string o = obj.ToString();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Object arg0 = (Object)luaMgr.GetNetObject(1);
		Object arg1 = (Object)luaMgr.GetNetObject(2);
		bool o = arg0 == arg1;
		luaMgr.PushResult(o);
		return 1;
	}
}

