using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using LuaInterface;

public class DictInt2StrWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Add", Add),
		new LuaMethod("Clear", Clear),
		new LuaMethod("ContainsKey", ContainsKey),
		new LuaMethod("ContainsValue", ContainsValue),
		new LuaMethod("GetObjectData", GetObjectData),
		new LuaMethod("OnDeserialization", OnDeserialization),
		new LuaMethod("Remove", Remove),
		new LuaMethod("TryGetValue", TryGetValue),
		new LuaMethod("GetEnumerator", GetEnumerator),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Count", get_Count, null),
		new LuaField("Comparer", get_Comparer, null),
		new LuaField("Keys", get_Keys, null),
		new LuaField("Values", get_Values, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(int)};
		Type[] types2 = {typeof(IDictionary<int,string>)};
		Type[] types3 = {typeof(IEqualityComparer<int>)};
		Type[] types4 = {typeof(int), typeof(IEqualityComparer<int>)};
		Type[] types5 = {typeof(IDictionary<int,string>), typeof(IEqualityComparer<int>)};

		if (count == 0)
		{
			Dictionary<int,string> obj = new Dictionary<int,string>();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Dictionary<int,string> obj = new Dictionary<int,string>(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			IDictionary<int,string> arg0 = LuaScriptMgr.GetNetObject<IDictionary<int,string>>(L, 1);
			Dictionary<int,string> obj = new Dictionary<int,string>(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			IEqualityComparer<int> arg0 = LuaScriptMgr.GetNetObject<IEqualityComparer<int>>(L, 1);
			Dictionary<int,string> obj = new Dictionary<int,string>(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			IEqualityComparer<int> arg1 = LuaScriptMgr.GetNetObject<IEqualityComparer<int>>(L, 2);
			Dictionary<int,string> obj = new Dictionary<int,string>(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types5, 1))
		{
			IDictionary<int,string> arg0 = LuaScriptMgr.GetNetObject<IDictionary<int,string>>(L, 1);
			IEqualityComparer<int> arg1 = LuaScriptMgr.GetNetObject<IEqualityComparer<int>>(L, 2);
			Dictionary<int,string> obj = new Dictionary<int,string>(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Dictionary<int,string>.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Dictionary<int,string>));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "DictInt2Str", typeof(Dictionary<int,string>), regs, fields, "object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Count");
		}

		Dictionary<int,string> obj = (Dictionary<int,string>)o;
		LuaScriptMgr.Push(L, obj.Count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Comparer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Comparer");
		}

		Dictionary<int,string> obj = (Dictionary<int,string>)o;
		LuaScriptMgr.PushObject(L, obj.Comparer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Keys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Keys");
		}

		Dictionary<int,string> obj = (Dictionary<int,string>)o;
		LuaScriptMgr.PushObject(L, obj.Keys);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Values(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Values");
		}

		Dictionary<int,string> obj = (Dictionary<int,string>)o;
		LuaScriptMgr.PushObject(L, obj.Values);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.Add(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		obj.Clear();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.ContainsKey(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.ContainsValue(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetObjectData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		SerializationInfo arg0 = LuaScriptMgr.GetNetObject<SerializationInfo>(L, 2);
		StreamingContext arg1 = LuaScriptMgr.GetNetObject<StreamingContext>(L, 3);
		obj.GetObjectData(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDeserialization(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.OnDeserialization(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.Remove(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TryGetValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetNetObject<string>(L, 3);
		bool o = obj.TryGetValue(arg0,out arg1);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.Push(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<int,string> obj = LuaScriptMgr.GetNetObject<Dictionary<int,string>>(L, 1);
		Dictionary<int,string>.Enumerator o = obj.GetEnumerator();
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}
}

