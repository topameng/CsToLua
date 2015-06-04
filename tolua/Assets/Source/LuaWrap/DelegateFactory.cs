using System;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public static class DelegateFactory
{
	delegate Delegate DelegateValue(LuaFunction func);
	static Dictionary<Type, DelegateValue> dict = new Dictionary<Type, DelegateValue>();

	[NoToLuaAttribute]
	public static void Register(IntPtr L)
	{
		dict.Add(typeof(Action<GameObject>), new DelegateValue(Action_GameObject));
		dict.Add(typeof(Action<GameObject,int,string>), new DelegateValue(Action_GameObject_int_string));
		dict.Add(typeof(Action<int,int,int,List<int>>), new DelegateValue(Action_int_int_int_List_int));
	}

	public static Delegate CreateDelegate(Type t, LuaFunction func)
	{
		DelegateValue create = null;

		if (!dict.TryGetValue(t, out create))
		{
			Debugger.LogError("Delegate {0} not register", t.FullName);
			return null;
		}
		return create(func);
	}

	public static Delegate Action_GameObject(LuaFunction func)
	{
		Action<GameObject> d = (arg0) =>
		{
			int top = func.BeginPCall();
			IntPtr L = func.GetLuaState();
			LuaScriptMgr.Push(L, arg0);
			func.PCall(top, 1);
			func.EndPCall(top);
		};
		return d;
	}

	public static Delegate Action_GameObject_int_string(LuaFunction func)
	{
		Action<GameObject,int,string> d = (arg0, arg1, arg2) =>
		{
			int top = func.BeginPCall();
			IntPtr L = func.GetLuaState();
			LuaScriptMgr.Push(L, arg0);
			LuaScriptMgr.Push(L, arg1);
			LuaScriptMgr.Push(L, arg2);
			func.PCall(top, 3);
			func.EndPCall(top);
		};
		return d;
	}

	public static Delegate Action_int_int_int_List_int(LuaFunction func)
	{
		Action<int,int,int,List<int>> d = (arg0, arg1, arg2, arg3) =>
		{
			int top = func.BeginPCall();
			IntPtr L = func.GetLuaState();
			LuaScriptMgr.Push(L, arg0);
			LuaScriptMgr.Push(L, arg1);
			LuaScriptMgr.Push(L, arg2);
			LuaScriptMgr.PushObject(L, arg3);
			func.PCall(top, 4);
			func.EndPCall(top);
		};
		return d;
	}

}
