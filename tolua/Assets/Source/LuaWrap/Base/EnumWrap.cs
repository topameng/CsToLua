using System;
using LuaInterface;

public class EnumWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetTypeCode", GetTypeCode),
		new LuaMethod("GetValues", GetValues),
		new LuaMethod("GetNames", GetNames),
		new LuaMethod("GetName", GetName),
		new LuaMethod("IsDefined", IsDefined),
		new LuaMethod("GetUnderlyingType", GetUnderlyingType),
		new LuaMethod("Parse", Parse),
		new LuaMethod("CompareTo", CompareTo),
		new LuaMethod("ToString", ToString),
		new LuaMethod("ToObject", ToObject),
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Format", Format),
		new LuaMethod("GetType", GetType),
		new LuaMethod("New", _CreateEnum),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
        new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateEnum(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Enum class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Enum));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "System.Enum", typeof(Enum), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = LuaScriptMgr.GetLuaObject(L, 1);
		if (obj != null)
		{
			LuaScriptMgr.Push(L, obj.ToString());
		}
		else
		{
			LuaScriptMgr.Push(L, "Table: System.Enum");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Enum obj = LuaScriptMgr.GetNetObject<Enum>(L, 1);
		TypeCode o = obj.GetTypeCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetValues(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		Array o = Enum.GetValues(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNames(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		string[] o = Enum.GetNames(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		string o = Enum.GetName(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsDefined(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = Enum.IsDefined(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUnderlyingType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		Type o = Enum.GetUnderlyingType(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Parse(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 2)
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			object o = Enum.Parse(arg0,arg1);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			object o = Enum.Parse(arg0,arg1,arg2);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Enum.Parse");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Enum obj = LuaScriptMgr.GetNetObject<Enum>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		int o = obj.CompareTo(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 1)
		{
			Enum obj = LuaScriptMgr.GetNetObject<Enum>(L, 1);
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Enum obj = LuaScriptMgr.GetNetObject<Enum>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Enum.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(long)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			long arg1 = (long)LuaScriptMgr.GetNumber(L, 2);
			object o = Enum.ToObject(arg0,arg1);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object)))
		{
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object o = Enum.ToObject(arg0,arg1);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Enum.ToObject");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Enum obj = LuaScriptMgr.GetNetObject<Enum>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Enum obj = LuaScriptMgr.GetNetObject<Enum>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Format(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		string arg2 = LuaScriptMgr.GetLuaString(L, 3);
		string o = Enum.Format(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Enum obj = LuaScriptMgr.GetNetObject<Enum>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Lua_Eq(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 2);
        Enum arg0 = LuaScriptMgr.GetVarObject(L, 1) as Enum;
        Enum arg1 = LuaScriptMgr.GetVarObject(L, 2) as Enum;
        bool o = Enum.Equals(arg0, arg1);
        LuaScriptMgr.Push(L, o);
        return 1;
    }
}

