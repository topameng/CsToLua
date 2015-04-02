using System;
using UnityEngine;
using System.Collections;
using LuaInterface;
using Object = UnityEngine.Object;

public class MonoBehaviourWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Invoke", Invoke),
		new LuaMethod("InvokeRepeating", InvokeRepeating),
		new LuaMethod("CancelInvoke", CancelInvoke),
		new LuaMethod("IsInvoking", IsInvoking),
		new LuaMethod("StartCoroutine", StartCoroutine),
		new LuaMethod("StartCoroutine_Auto", StartCoroutine_Auto),
		new LuaMethod("StopCoroutine", StopCoroutine),
		new LuaMethod("StopAllCoroutines", StopAllCoroutines),
		new LuaMethod("print", print),
		new LuaMethod("New", _CreateMonoBehaviour),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("useGUILayout", get_useGUILayout, set_useGUILayout),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMonoBehaviour(IntPtr L)
	{
		LuaDLL.luaL_error(L, "MonoBehaviour class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(MonoBehaviour));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.MonoBehaviour", typeof(MonoBehaviour), regs, fields, typeof(UnityEngine.Behaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useGUILayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MonoBehaviour obj = (MonoBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useGUILayout");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useGUILayout on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.useGUILayout);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGUILayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MonoBehaviour obj = (MonoBehaviour)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useGUILayout");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useGUILayout on a nil value");
			}
		}

		obj.useGUILayout = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Invoke(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.Invoke(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InvokeRepeating(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		obj.InvokeRepeating(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CancelInvoke(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 1)
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			obj.CancelInvoke();
			return 0;
		}
		else if (count == 2)
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.CancelInvoke(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.CancelInvoke");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInvoking(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 1)
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			bool o = obj.IsInvoking();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool o = obj.IsInvoking(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.IsInvoking");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(MonoBehaviour), typeof(string)))
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Coroutine o = obj.StartCoroutine(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(MonoBehaviour), typeof(IEnumerator)))
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
			Coroutine o = obj.StartCoroutine(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			Coroutine o = obj.StartCoroutine(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.StartCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine_Auto(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
		IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
		Coroutine o = obj.StartCoroutine_Auto(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(MonoBehaviour), typeof(Coroutine)))
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			Coroutine arg0 = LuaScriptMgr.GetNetObject<Coroutine>(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(MonoBehaviour), typeof(IEnumerator)))
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(MonoBehaviour), typeof(string)))
		{
			MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.StopCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAllCoroutines(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MonoBehaviour obj = LuaScriptMgr.GetUnityObject<MonoBehaviour>(L, 1);
		obj.StopAllCoroutines();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int print(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		MonoBehaviour.print(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetVarObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetVarObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

