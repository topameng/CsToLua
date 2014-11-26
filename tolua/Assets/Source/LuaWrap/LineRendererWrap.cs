using UnityEngine;
using System;
using LuaInterface;

public class LineRendererWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetWidth", SetWidth),
		new LuaMethod("SetColors", SetColors),
		new LuaMethod("SetVertexCount", SetVertexCount),
		new LuaMethod("SetPosition", SetPosition),
		new LuaMethod("New", _CreateLineRenderer),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("useWorldSpace", get_useWorldSpace, set_useWorldSpace),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLineRenderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LineRenderer obj = new LineRenderer();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LineRenderer.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LineRenderer));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LineRenderer", typeof(LineRenderer), regs, fields, "UnityEngine.Renderer");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useWorldSpace(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useWorldSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useWorldSpace on a nil value");
			}
		}

		LineRenderer obj = (LineRenderer)o;
		LuaScriptMgr.Push(L, obj.useWorldSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useWorldSpace(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useWorldSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useWorldSpace on a nil value");
			}
		}

		LineRenderer obj = (LineRenderer)o;
		obj.useWorldSpace = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetWidth(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LineRenderer obj = LuaScriptMgr.GetNetObject<LineRenderer>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.SetWidth(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetColors(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LineRenderer obj = LuaScriptMgr.GetNetObject<LineRenderer>(L, 1);
		Color arg0 = LuaScriptMgr.GetNetObject<Color>(L, 2);
		Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 3);
		obj.SetColors(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetVertexCount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LineRenderer obj = LuaScriptMgr.GetNetObject<LineRenderer>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.SetVertexCount(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPosition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LineRenderer obj = LuaScriptMgr.GetNetObject<LineRenderer>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		obj.SetPosition(arg0,arg1);
		return 0;
	}
}

