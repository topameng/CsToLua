using UnityEngine;
using System;
using LuaInterface;

public class ClothWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateCloth),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("bendingStiffness", get_bendingStiffness, set_bendingStiffness),
		new LuaField("stretchingStiffness", get_stretchingStiffness, set_stretchingStiffness),
		new LuaField("damping", get_damping, set_damping),
		new LuaField("thickness", get_thickness, set_thickness),
		new LuaField("externalAcceleration", get_externalAcceleration, set_externalAcceleration),
		new LuaField("randomAcceleration", get_randomAcceleration, set_randomAcceleration),
		new LuaField("useGravity", get_useGravity, set_useGravity),
		new LuaField("selfCollision", get_selfCollision, set_selfCollision),
		new LuaField("enabled", get_enabled, set_enabled),
		new LuaField("vertices", get_vertices, null),
		new LuaField("normals", get_normals, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCloth(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Cloth obj = new Cloth();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Cloth.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Cloth));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Cloth", typeof(Cloth), regs, fields, "UnityEngine.Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bendingStiffness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bendingStiffness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bendingStiffness on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.Push(L, obj.bendingStiffness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stretchingStiffness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stretchingStiffness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stretchingStiffness on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.Push(L, obj.stretchingStiffness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_damping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name damping");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index damping on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.Push(L, obj.damping);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_thickness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name thickness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index thickness on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.Push(L, obj.thickness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_externalAcceleration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name externalAcceleration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index externalAcceleration on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.PushValue(L, obj.externalAcceleration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_randomAcceleration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name randomAcceleration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index randomAcceleration on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.PushValue(L, obj.randomAcceleration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useGravity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useGravity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useGravity on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.Push(L, obj.useGravity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selfCollision(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selfCollision");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selfCollision on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.Push(L, obj.selfCollision);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.Push(L, obj.enabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vertices(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vertices");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vertices on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.PushArray(L, obj.vertices);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_normals(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name normals");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index normals on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		LuaScriptMgr.PushArray(L, obj.normals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bendingStiffness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bendingStiffness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bendingStiffness on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.bendingStiffness = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stretchingStiffness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stretchingStiffness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stretchingStiffness on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.stretchingStiffness = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_damping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name damping");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index damping on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.damping = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_thickness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name thickness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index thickness on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.thickness = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_externalAcceleration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name externalAcceleration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index externalAcceleration on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.externalAcceleration = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_randomAcceleration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name randomAcceleration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index randomAcceleration on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.randomAcceleration = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGravity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useGravity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useGravity on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.useGravity = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selfCollision(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selfCollision");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selfCollision on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.selfCollision = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}

		Cloth obj = (Cloth)o;
		obj.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

