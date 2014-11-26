using UnityEngine;
using System;
using LuaInterface;

public class ProjectorWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateProjector),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("nearClipPlane", get_nearClipPlane, set_nearClipPlane),
		new LuaField("farClipPlane", get_farClipPlane, set_farClipPlane),
		new LuaField("fieldOfView", get_fieldOfView, set_fieldOfView),
		new LuaField("aspectRatio", get_aspectRatio, set_aspectRatio),
		new LuaField("isOrthoGraphic", get_isOrthoGraphic, set_isOrthoGraphic),
		new LuaField("orthographic", get_orthographic, set_orthographic),
		new LuaField("orthographicSize", get_orthographicSize, set_orthographicSize),
		new LuaField("orthoGraphicSize", get_orthoGraphicSize, set_orthoGraphicSize),
		new LuaField("ignoreLayers", get_ignoreLayers, set_ignoreLayers),
		new LuaField("material", get_material, set_material),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateProjector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Projector obj = new Projector();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Projector.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Projector));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Projector", typeof(Projector), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nearClipPlane(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nearClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nearClipPlane on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.nearClipPlane);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_farClipPlane(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name farClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index farClipPlane on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.farClipPlane);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fieldOfView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fieldOfView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fieldOfView on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.fieldOfView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_aspectRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspectRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspectRatio on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.aspectRatio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isOrthoGraphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOrthoGraphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOrthoGraphic on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.isOrthoGraphic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthographic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographic on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.orthographic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthographicSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographicSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographicSize on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.orthographicSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthoGraphicSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthoGraphicSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthoGraphicSize on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.orthoGraphicSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ignoreLayers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ignoreLayers");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ignoreLayers on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.ignoreLayers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}

		Projector obj = (Projector)o;
		LuaScriptMgr.Push(L, obj.material);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_nearClipPlane(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nearClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nearClipPlane on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.nearClipPlane = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_farClipPlane(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name farClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index farClipPlane on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.farClipPlane = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fieldOfView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fieldOfView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fieldOfView on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.fieldOfView = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_aspectRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspectRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspectRatio on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.aspectRatio = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isOrthoGraphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOrthoGraphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOrthoGraphic on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.isOrthoGraphic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthographic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographic on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.orthographic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthographicSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographicSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographicSize on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.orthographicSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthoGraphicSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthoGraphicSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthoGraphicSize on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.orthoGraphicSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ignoreLayers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ignoreLayers");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ignoreLayers on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.ignoreLayers = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}

		Projector obj = (Projector)o;
		obj.material = LuaScriptMgr.GetNetObject<Material>(L, 3);
		return 0;
	}
}

