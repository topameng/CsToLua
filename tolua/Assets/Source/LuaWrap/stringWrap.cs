using System;
using LuaInterface;

public class stringWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Equals", Equals),
			new LuaMethod("Clone", Clone),
			new LuaMethod("GetTypeCode", GetTypeCode),
			new LuaMethod("CopyTo", CopyTo),
			new LuaMethod("ToCharArray", ToCharArray),
			new LuaMethod("Split", Split),
			new LuaMethod("Substring", Substring),
			new LuaMethod("Trim", Trim),
			new LuaMethod("TrimStart", TrimStart),
			new LuaMethod("TrimEnd", TrimEnd),
			new LuaMethod("Compare", Compare),
			new LuaMethod("CompareTo", CompareTo),
			new LuaMethod("CompareOrdinal", CompareOrdinal),
			new LuaMethod("EndsWith", EndsWith),
			new LuaMethod("IndexOfAny", IndexOfAny),
			new LuaMethod("IndexOf", IndexOf),
			new LuaMethod("LastIndexOf", LastIndexOf),
			new LuaMethod("LastIndexOfAny", LastIndexOfAny),
			new LuaMethod("Contains", Contains),
			new LuaMethod("IsNullOrEmpty", IsNullOrEmpty),
			new LuaMethod("Normalize", Normalize),
			new LuaMethod("IsNormalized", IsNormalized),
			new LuaMethod("Remove", Remove),
			new LuaMethod("PadLeft", PadLeft),
			new LuaMethod("PadRight", PadRight),
			new LuaMethod("StartsWith", StartsWith),
			new LuaMethod("Replace", Replace),
			new LuaMethod("ToLower", ToLower),
			new LuaMethod("ToLowerInvariant", ToLowerInvariant),
			new LuaMethod("ToUpper", ToUpper),
			new LuaMethod("ToUpperInvariant", ToUpperInvariant),
			new LuaMethod("ToString", ToString),
			new LuaMethod("Format", Format),
			new LuaMethod("Copy", Copy),
			new LuaMethod("Concat", Concat),
			new LuaMethod("Insert", Insert),
			new LuaMethod("Intern", Intern),
			new LuaMethod("IsInterned", IsInterned),
			new LuaMethod("Join", Join),
			new LuaMethod("GetEnumerator", GetEnumerator),
			new LuaMethod("GetHashCode", GetHashCode),
			new LuaMethod("New", _Createstring),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Empty", get_Empty, null),
			new LuaField("Length", get_Length, null),
		};

		LuaScriptMgr.RegisterLib(L, "System.String", typeof(System.String), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _Createstring(IntPtr L)
	{
        LuaTypes luatype = LuaDLL.lua_type(L, 1);

        if (luatype == LuaTypes.LUA_TSTRING)
        {
            string arg0 = LuaDLL.lua_tostring(L, 1);
            LuaScriptMgr.PushObject(L, arg0);
            return 1;
        }
        else
        {
            LuaDLL.luaL_error(L, "invalid arguments to method: String.New");
        }
        
		return 0;
	}

	static Type classType = typeof(string);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Empty(IntPtr L)
	{
		LuaScriptMgr.Push(L, string.Empty);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Length(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		string obj = (string)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Length");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Length on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Length);
		return 1;
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
			LuaScriptMgr.Push(L, "Table: System.String");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(string)))
		{
			string obj = LuaScriptMgr.GetVarObject(L, 1) as string;
			string arg0 = LuaScriptMgr.GetString(L, 2);
			bool o = obj != null ? obj.Equals(arg0) : arg0 == null;
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(object)))
		{
			string obj = LuaScriptMgr.GetVarObject(L, 1) as string;
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			bool o = obj != null ? obj.Equals(arg0) : arg0 == null;
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = LuaScriptMgr.GetVarObject(L, 1) as string;
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			StringComparison arg1 = (StringComparison)LuaScriptMgr.GetNetObject(L, 3, typeof(StringComparison));
			bool o = obj != null ? obj.Equals(arg0, arg1) : arg0 == null;
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Equals");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		object o = obj.Clone();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		TypeCode o = obj.GetTypeCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyTo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		char[] objs1 = LuaScriptMgr.GetArrayNumber<char>(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
		obj.CopyTo(arg0,objs1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToCharArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] o = obj.ToCharArray();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			char[] o = obj.ToCharArray(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.ToCharArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Split(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(char[]), typeof(StringSplitOptions)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			StringSplitOptions arg1 = (StringSplitOptions)LuaScriptMgr.GetLuaObject(L, 3);
			string[] o = obj.Split(objs0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(char[]), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			string[] o = obj.Split(objs0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(string[]), typeof(StringSplitOptions)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string[] objs0 = LuaScriptMgr.GetArrayString(L, 2);
			StringSplitOptions arg1 = (StringSplitOptions)LuaScriptMgr.GetLuaObject(L, 3);
			string[] o = obj.Split(objs0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 2, typeof(string[]), typeof(int), typeof(StringSplitOptions)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string[] objs0 = LuaScriptMgr.GetArrayString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			StringSplitOptions arg2 = (StringSplitOptions)LuaScriptMgr.GetLuaObject(L, 4);
			string[] o = obj.Split(objs0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 2, typeof(char[]), typeof(int), typeof(StringSplitOptions)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			StringSplitOptions arg2 = (StringSplitOptions)LuaScriptMgr.GetLuaObject(L, 4);
			string[] o = obj.Split(objs0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(char), 2, count - 1))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			string[] o = obj.Split(objs0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Split");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Substring(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			string o = obj.Substring(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			string o = obj.Substring(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Substring");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Trim(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string o = obj.Trim();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(char), 2, count - 1))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			string o = obj.Trim(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Trim");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TrimStart(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
		string o = obj.TrimStart(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TrimEnd(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
		string o = obj.TrimEnd(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Compare(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			int o = string.Compare(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(string), typeof(StringComparison)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			StringComparison arg2 = (StringComparison)LuaScriptMgr.GetLuaObject(L, 3);
			int o = string.Compare(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(string), typeof(bool)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			bool arg2 = LuaDLL.lua_toboolean(L, 3);
			int o = string.Compare(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(string), typeof(System.Globalization.CultureInfo), typeof(System.Globalization.CompareOptions)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			System.Globalization.CultureInfo arg2 = (System.Globalization.CultureInfo)LuaScriptMgr.GetLuaObject(L, 3);
			System.Globalization.CompareOptions arg3 = (System.Globalization.CompareOptions)LuaScriptMgr.GetLuaObject(L, 4);
			int o = string.Compare(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(string), typeof(bool), typeof(System.Globalization.CultureInfo)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			bool arg2 = LuaDLL.lua_toboolean(L, 3);
			System.Globalization.CultureInfo arg3 = (System.Globalization.CultureInfo)LuaScriptMgr.GetLuaObject(L, 4);
			int o = string.Compare(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			string arg2 = LuaScriptMgr.GetLuaString(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			int o = string.Compare(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(StringComparison)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg4 = (int)LuaDLL.lua_tonumber(L, 5);
			StringComparison arg5 = (StringComparison)LuaScriptMgr.GetLuaObject(L, 6);
			int o = string.Compare(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(bool)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg4 = (int)LuaDLL.lua_tonumber(L, 5);
			bool arg5 = LuaDLL.lua_toboolean(L, 6);
			int o = string.Compare(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(System.Globalization.CultureInfo), typeof(System.Globalization.CompareOptions)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg4 = (int)LuaDLL.lua_tonumber(L, 5);
			System.Globalization.CultureInfo arg5 = (System.Globalization.CultureInfo)LuaScriptMgr.GetLuaObject(L, 6);
			System.Globalization.CompareOptions arg6 = (System.Globalization.CompareOptions)LuaScriptMgr.GetLuaObject(L, 7);
			int o = string.Compare(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(System.Globalization.CultureInfo)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg4 = (int)LuaDLL.lua_tonumber(L, 5);
			bool arg5 = LuaDLL.lua_toboolean(L, 6);
			System.Globalization.CultureInfo arg6 = (System.Globalization.CultureInfo)LuaScriptMgr.GetLuaObject(L, 7);
			int o = string.Compare(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Compare");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(string)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int o = obj.CompareTo(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(object)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			int o = obj.CompareTo(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.CompareTo");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareOrdinal(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			int o = string.CompareOrdinal(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			string arg2 = LuaScriptMgr.GetLuaString(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			int o = string.CompareOrdinal(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.CompareOrdinal");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndsWith(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool o = obj.EndsWith(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			StringComparison arg1 = (StringComparison)LuaScriptMgr.GetNetObject(L, 3, typeof(StringComparison));
			bool o = obj.EndsWith(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			System.Globalization.CultureInfo arg2 = (System.Globalization.CultureInfo)LuaScriptMgr.GetNetObject(L, 4, typeof(System.Globalization.CultureInfo));
			bool o = obj.EndsWith(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.EndsWith");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IndexOfAny(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int o = obj.IndexOfAny(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int o = obj.IndexOfAny(objs0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int o = obj.IndexOfAny(objs0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.IndexOfAny");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IndexOf(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(char)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char arg0 = (char)LuaDLL.lua_tonumber(L, 2);
			int o = obj.IndexOf(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(string)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int o = obj.IndexOf(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int o = obj.IndexOf(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(char), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char arg0 = (char)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int o = obj.IndexOf(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(StringComparison)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			StringComparison arg1 = (StringComparison)LuaScriptMgr.GetLuaObject(L, 3);
			int o = obj.IndexOf(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(int), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int o = obj.IndexOf(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(int), typeof(StringComparison)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			StringComparison arg2 = (StringComparison)LuaScriptMgr.GetLuaObject(L, 4);
			int o = obj.IndexOf(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 2, typeof(char), typeof(int), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char arg0 = (char)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int o = obj.IndexOf(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			StringComparison arg3 = (StringComparison)LuaScriptMgr.GetNetObject(L, 5, typeof(StringComparison));
			int o = obj.IndexOf(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.IndexOf");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LastIndexOf(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(char)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char arg0 = (char)LuaDLL.lua_tonumber(L, 2);
			int o = obj.LastIndexOf(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(string)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int o = obj.LastIndexOf(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int o = obj.LastIndexOf(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(char), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char arg0 = (char)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int o = obj.LastIndexOf(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(StringComparison)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			StringComparison arg1 = (StringComparison)LuaScriptMgr.GetLuaObject(L, 3);
			int o = obj.LastIndexOf(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(int), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int o = obj.LastIndexOf(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(int), typeof(StringComparison)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			StringComparison arg2 = (StringComparison)LuaScriptMgr.GetLuaObject(L, 4);
			int o = obj.LastIndexOf(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 2, typeof(char), typeof(int), typeof(int)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char arg0 = (char)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int o = obj.LastIndexOf(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			StringComparison arg3 = (StringComparison)LuaScriptMgr.GetNetObject(L, 5, typeof(StringComparison));
			int o = obj.LastIndexOf(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.LastIndexOf");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LastIndexOfAny(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int o = obj.LastIndexOfAny(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int o = obj.LastIndexOfAny(objs0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int o = obj.LastIndexOfAny(objs0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.LastIndexOfAny");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.Contains(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsNullOrEmpty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = string.IsNullOrEmpty(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Normalize(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string o = obj.Normalize();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			System.Text.NormalizationForm arg0 = (System.Text.NormalizationForm)LuaScriptMgr.GetNetObject(L, 2, typeof(System.Text.NormalizationForm));
			string o = obj.Normalize(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Normalize");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsNormalized(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			bool o = obj.IsNormalized();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			System.Text.NormalizationForm arg0 = (System.Text.NormalizationForm)LuaScriptMgr.GetNetObject(L, 2, typeof(System.Text.NormalizationForm));
			bool o = obj.IsNormalized(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.IsNormalized");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			string o = obj.Remove(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			string o = obj.Remove(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Remove");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PadLeft(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			string o = obj.PadLeft(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			char arg1 = (char)LuaScriptMgr.GetNumber(L, 3);
			string o = obj.PadLeft(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.PadLeft");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PadRight(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			string o = obj.PadRight(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			char arg1 = (char)LuaScriptMgr.GetNumber(L, 3);
			string o = obj.PadRight(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.PadRight");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartsWith(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool o = obj.StartsWith(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			StringComparison arg1 = (StringComparison)LuaScriptMgr.GetNetObject(L, 3, typeof(StringComparison));
			bool o = obj.StartsWith(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			System.Globalization.CultureInfo arg2 = (System.Globalization.CultureInfo)LuaScriptMgr.GetNetObject(L, 4, typeof(System.Globalization.CultureInfo));
			bool o = obj.StartsWith(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.StartsWith");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Replace(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(string), typeof(string)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			string arg1 = LuaScriptMgr.GetString(L, 3);
			string o = obj.Replace(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 2, typeof(char), typeof(char)))
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			char arg0 = (char)LuaDLL.lua_tonumber(L, 2);
			char arg1 = (char)LuaDLL.lua_tonumber(L, 3);
			string o = obj.Replace(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Replace");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToLower(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string o = obj.ToLower();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			System.Globalization.CultureInfo arg0 = (System.Globalization.CultureInfo)LuaScriptMgr.GetNetObject(L, 2, typeof(System.Globalization.CultureInfo));
			string o = obj.ToLower(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.ToLower");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToLowerInvariant(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		string o = obj.ToLowerInvariant();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToUpper(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string o = obj.ToUpper();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			System.Globalization.CultureInfo arg0 = (System.Globalization.CultureInfo)LuaScriptMgr.GetNetObject(L, 2, typeof(System.Globalization.CultureInfo));
			string o = obj.ToUpper(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.ToUpper");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToUpperInvariant(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		string o = obj.ToUpperInvariant();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
			IFormatProvider arg0 = (IFormatProvider)LuaScriptMgr.GetNetObject(L, 2, typeof(IFormatProvider));
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Format(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			string o = string.Format(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(object), typeof(object)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			string o = string.Format(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			string o = string.Format(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(IFormatProvider), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 3, count - 2))
		{
			IFormatProvider arg0 = (IFormatProvider)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			object[] objs2 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
			string o = string.Format(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			string o = string.Format(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Format");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Copy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = string.Copy(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Concat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			string o = string.Concat(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			string o = string.Concat(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(object), typeof(object)))
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			string o = string.Concat(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(string), typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			string o = string.Concat(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(object), typeof(object), typeof(object)))
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			string o = string.Concat(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(string), typeof(string), typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			string arg3 = LuaScriptMgr.GetString(L, 4);
			string o = string.Concat(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(object), typeof(object), typeof(object), typeof(object)))
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			string o = string.Concat(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(string), 1, count))
		{
			string[] objs0 = LuaScriptMgr.GetParamsString(L, 1, count);
			string o = string.Concat(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(object), 1, count))
		{
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
			string o = string.Concat(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Concat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Insert(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		string o = obj.Insert(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Intern(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = string.Intern(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInterned(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = string.IsInterned(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Join(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
			string o = string.Join(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			string o = string.Join(arg0,objs1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: string.Join");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		CharEnumerator o = obj.GetEnumerator();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string obj = (string)LuaScriptMgr.GetNetObjectSelf(L, 1, "string");
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

