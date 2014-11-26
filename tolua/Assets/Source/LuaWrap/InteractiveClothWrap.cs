using UnityEngine;
using System;
using LuaInterface;

public class InteractiveClothWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("AddForceAtPosition", AddForceAtPosition),
		new LuaMethod("AttachToCollider", AttachToCollider),
		new LuaMethod("DetachFromCollider", DetachFromCollider),
		new LuaMethod("New", _CreateInteractiveCloth),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("mesh", get_mesh, set_mesh),
		new LuaField("friction", get_friction, set_friction),
		new LuaField("density", get_density, set_density),
		new LuaField("pressure", get_pressure, set_pressure),
		new LuaField("collisionResponse", get_collisionResponse, set_collisionResponse),
		new LuaField("tearFactor", get_tearFactor, set_tearFactor),
		new LuaField("attachmentTearFactor", get_attachmentTearFactor, set_attachmentTearFactor),
		new LuaField("attachmentResponse", get_attachmentResponse, set_attachmentResponse),
		new LuaField("isTeared", get_isTeared, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateInteractiveCloth(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			InteractiveCloth obj = new InteractiveCloth();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: InteractiveCloth.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(InteractiveCloth));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.InteractiveCloth", typeof(InteractiveCloth), regs, fields, "UnityEngine.Cloth");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mesh(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mesh");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mesh on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.mesh);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_friction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name friction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index friction on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.friction);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_density(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name density");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index density on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.density);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pressure(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pressure");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pressure on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.pressure);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collisionResponse(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name collisionResponse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index collisionResponse on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.collisionResponse);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tearFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tearFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tearFactor on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.tearFactor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_attachmentTearFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name attachmentTearFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index attachmentTearFactor on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.attachmentTearFactor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_attachmentResponse(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name attachmentResponse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index attachmentResponse on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.attachmentResponse);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isTeared(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isTeared");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isTeared on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		LuaScriptMgr.Push(L, obj.isTeared);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mesh(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mesh");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mesh on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		obj.mesh = LuaScriptMgr.GetNetObject<Mesh>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_friction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name friction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index friction on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		obj.friction = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_density(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name density");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index density on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		obj.density = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pressure(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pressure");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pressure on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		obj.pressure = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_collisionResponse(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name collisionResponse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index collisionResponse on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		obj.collisionResponse = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tearFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tearFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tearFactor on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		obj.tearFactor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_attachmentTearFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name attachmentTearFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index attachmentTearFactor on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		obj.attachmentTearFactor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_attachmentResponse(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name attachmentResponse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index attachmentResponse on a nil value");
			}
		}

		InteractiveCloth obj = (InteractiveCloth)o;
		obj.attachmentResponse = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddForceAtPosition(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			InteractiveCloth obj = LuaScriptMgr.GetNetObject<InteractiveCloth>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.AddForceAtPosition(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			InteractiveCloth obj = LuaScriptMgr.GetNetObject<InteractiveCloth>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			ForceMode arg3 = LuaScriptMgr.GetNetObject<ForceMode>(L, 5);
			obj.AddForceAtPosition(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: InteractiveCloth.AddForceAtPosition");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AttachToCollider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			InteractiveCloth obj = LuaScriptMgr.GetNetObject<InteractiveCloth>(L, 1);
			Collider arg0 = LuaScriptMgr.GetNetObject<Collider>(L, 2);
			obj.AttachToCollider(arg0);
			return 0;
		}
		else if (count == 3)
		{
			InteractiveCloth obj = LuaScriptMgr.GetNetObject<InteractiveCloth>(L, 1);
			Collider arg0 = LuaScriptMgr.GetNetObject<Collider>(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.AttachToCollider(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			InteractiveCloth obj = LuaScriptMgr.GetNetObject<InteractiveCloth>(L, 1);
			Collider arg0 = LuaScriptMgr.GetNetObject<Collider>(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			obj.AttachToCollider(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: InteractiveCloth.AttachToCollider");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DetachFromCollider(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		InteractiveCloth obj = LuaScriptMgr.GetNetObject<InteractiveCloth>(L, 1);
		Collider arg0 = LuaScriptMgr.GetNetObject<Collider>(L, 2);
		obj.DetachFromCollider(arg0);
		return 0;
	}
}

