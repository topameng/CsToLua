using System;
using System.Reflection;
using System.Runtime.Serialization;
using LuaInterface;

public class DelegateWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("CreateDelegate", CreateDelegate),
		new LuaMethod("DynamicInvoke", DynamicInvoke),
		new LuaMethod("Clone", Clone),
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetObjectData", GetObjectData),
		new LuaMethod("GetInvocationList", GetInvocationList),
		new LuaMethod("Combine", Combine),
		new LuaMethod("Remove", Remove),
	        new LuaMethod("Add", Add),
		new LuaMethod("RemoveAll", RemoveAll),
		new LuaMethod("New", _CreateDelegate),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Method", get_Method, null),
		new LuaField("Target", get_Target, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDelegate(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Delegate class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Delegate));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "System.Delegate", typeof(Delegate), regs, fields, typeof(System.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Method(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Delegate obj = (Delegate)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Method");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Method on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.Method);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Delegate obj = (Delegate)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Target on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.Target);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateDelegate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			MethodInfo arg1 = LuaScriptMgr.GetNetObject<MethodInfo>(L, 2);
			Delegate o = Delegate.CreateDelegate(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(MethodInfo), typeof(bool)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			MethodInfo arg1 = LuaScriptMgr.GetNetObject<MethodInfo>(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(Type), typeof(string)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(string)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(MethodInfo)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			MethodInfo arg2 = LuaScriptMgr.GetNetObject<MethodInfo>(L, 3);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(Type), typeof(string), typeof(bool)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(string), typeof(bool)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(MethodInfo), typeof(bool)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			MethodInfo arg2 = LuaScriptMgr.GetNetObject<MethodInfo>(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(Type), typeof(string), typeof(bool), typeof(bool)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(string), typeof(bool), typeof(bool)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			Delegate o = Delegate.CreateDelegate(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Delegate.CreateDelegate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DynamicInvoke(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Delegate obj = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		object o = obj.DynamicInvoke(objs0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Delegate obj = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
		object o = obj.Clone();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate obj = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Delegate obj = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetObjectData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Delegate obj = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
		SerializationInfo arg0 = LuaScriptMgr.GetNetObject<SerializationInfo>(L, 2);
		StreamingContext arg1 = LuaScriptMgr.GetNetObject<StreamingContext>(L, 3);
		obj.GetObjectData(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInvocationList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Delegate obj = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
		Delegate[] o = obj.GetInvocationList();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Combine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (LuaScriptMgr.CheckParamsType(L, typeof(Delegate), 1, count))
		{
			Delegate[] objs0 = LuaScriptMgr.GetParamsObject<Delegate>(L, 1, count);
			Delegate o = Delegate.Combine(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Delegate arg0 = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
			Delegate arg1 = LuaScriptMgr.GetNetObject<Delegate>(L, 2);
			Delegate o = Delegate.Combine(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Delegate.Combine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate arg0 = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
		Delegate arg1 = LuaScriptMgr.GetNetObject<Delegate>(L, 2);
		Delegate o = Delegate.Remove(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Add(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 2);
        Delegate arg0 = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
        Delegate arg1 = LuaScriptMgr.GetNetObject<Delegate>(L, 2);
        Delegate o = Delegate.Combine(arg0, arg1);
        LuaScriptMgr.Push(L, o);
        return 1;
    }
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate arg0 = LuaScriptMgr.GetNetObject<Delegate>(L, 1);
		Delegate arg1 = LuaScriptMgr.GetNetObject<Delegate>(L, 2);
		Delegate o = Delegate.RemoveAll(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate arg0 = LuaScriptMgr.GetVarObject(L, 1) as Delegate;
		Delegate arg1 = LuaScriptMgr.GetVarObject(L, 2) as Delegate;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

