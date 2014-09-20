using UnityEngine;
using System.Collections;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class MonoBehaviourWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

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
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("useGUILayout", get_useGUILayout, set_useGUILayout),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object obj = null;

		if (count == 0)
		{
			obj = new MonoBehaviour();
			luaMgr.PushResult(obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'MonoBehaviour.New' has some invalid arguments");
		}

		return 0;
	}

	public void Register()
	{
		LuaMethod[] metas = new LuaMethod[]
		{
			new LuaMethod("__index", Lua_Index),
			new LuaMethod("__newindex", Lua_NewIndex),
		};

		luaMgr = LuaScriptMgr.Instance;
		reference = luaMgr.RegisterLib("MonoBehaviour", regs);
		luaMgr.CreateMetaTable("MonoBehaviour", metas, typeof(MonoBehaviour));
		luaMgr.RegisterField(typeof(MonoBehaviour), fields);
	}

	static bool get_useGUILayout(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		MonoBehaviour obj = (MonoBehaviour)o;
		luaMgr.PushResult(obj.useGUILayout);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return BehaviourWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'MonoBehaviour' does not contain a definition for '{0}'", str));
		return 0;
	}

	static bool set_useGUILayout(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		MonoBehaviour obj = (MonoBehaviour)o;
		obj.useGUILayout = luaMgr.GetBoolean(3);
		return true;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return BehaviourWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'MonoBehaviour' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Invoke(IntPtr l)
	{
		luaMgr.CheckArgsCount(3);
		MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
		string arg0 = luaMgr.GetString(2);
		float arg1 = (float)luaMgr.GetNumber(3);
		obj.Invoke(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InvokeRepeating(IntPtr l)
	{
		luaMgr.CheckArgsCount(4);
		MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
		string arg0 = luaMgr.GetString(2);
		float arg1 = (float)luaMgr.GetNumber(3);
		float arg2 = (float)luaMgr.GetNumber(4);
		obj.InvokeRepeating(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CancelInvoke(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			obj.CancelInvoke();
			return 0;
		}
		else if (count == 2)
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			obj.CancelInvoke(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'MonoBehaviour.CancelInvoke' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInvoking(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			bool o = obj.IsInvoking();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			bool o = obj.IsInvoking(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'MonoBehaviour.IsInvoking' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(MonoBehaviour), typeof(string)};
		Type[] types1 = {typeof(MonoBehaviour), typeof(IEnumerator)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Coroutine o = obj.StartCoroutine(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			IEnumerator arg0 = (IEnumerator)luaMgr.GetNetObject(2);
			Coroutine o = obj.StartCoroutine(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			object arg1 = (object)luaMgr.GetNetObject(3);
			Coroutine o = obj.StartCoroutine(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'MonoBehaviour.StartCoroutine' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine_Auto(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
		IEnumerator arg0 = (IEnumerator)luaMgr.GetNetObject(2);
		Coroutine o = obj.StartCoroutine_Auto(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopCoroutine(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(MonoBehaviour), typeof(IEnumerator)};
		Type[] types1 = {typeof(MonoBehaviour), typeof(string)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			IEnumerator arg0 = (IEnumerator)luaMgr.GetNetObject(2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'MonoBehaviour.StopCoroutine' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAllCoroutines(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		MonoBehaviour obj = (MonoBehaviour)luaMgr.GetNetObject(1);
		obj.StopAllCoroutines();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int print(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		object arg0 = (object)luaMgr.GetNetObject(1);
		MonoBehaviour.print(arg0);
		return 0;
	}
}

