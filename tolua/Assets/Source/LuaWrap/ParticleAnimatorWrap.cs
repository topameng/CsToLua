using UnityEngine;
using System;
using LuaInterface;

public class ParticleAnimatorWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateParticleAnimator),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("doesAnimateColor", get_doesAnimateColor, set_doesAnimateColor),
		new LuaField("worldRotationAxis", get_worldRotationAxis, set_worldRotationAxis),
		new LuaField("localRotationAxis", get_localRotationAxis, set_localRotationAxis),
		new LuaField("sizeGrow", get_sizeGrow, set_sizeGrow),
		new LuaField("rndForce", get_rndForce, set_rndForce),
		new LuaField("force", get_force, set_force),
		new LuaField("damping", get_damping, set_damping),
		new LuaField("autodestruct", get_autodestruct, set_autodestruct),
		new LuaField("colorAnimation", get_colorAnimation, set_colorAnimation),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateParticleAnimator(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ParticleAnimator obj = new ParticleAnimator();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleAnimator.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ParticleAnimator));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleAnimator", typeof(ParticleAnimator), regs, fields, "UnityEngine.Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_doesAnimateColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name doesAnimateColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index doesAnimateColor on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.Push(L, obj.doesAnimateColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldRotationAxis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldRotationAxis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldRotationAxis on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.PushValue(L, obj.worldRotationAxis);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localRotationAxis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localRotationAxis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localRotationAxis on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.PushValue(L, obj.localRotationAxis);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sizeGrow(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sizeGrow");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sizeGrow on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.Push(L, obj.sizeGrow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rndForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rndForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rndForce on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.PushValue(L, obj.rndForce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_force(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name force");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index force on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.PushValue(L, obj.force);
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

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.Push(L, obj.damping);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autodestruct(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autodestruct");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autodestruct on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.Push(L, obj.autodestruct);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorAnimation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorAnimation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorAnimation on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		LuaScriptMgr.PushArray(L, obj.colorAnimation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_doesAnimateColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name doesAnimateColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index doesAnimateColor on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.doesAnimateColor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_worldRotationAxis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldRotationAxis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldRotationAxis on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.worldRotationAxis = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localRotationAxis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localRotationAxis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localRotationAxis on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.localRotationAxis = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sizeGrow(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sizeGrow");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sizeGrow on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.sizeGrow = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rndForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rndForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rndForce on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.rndForce = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_force(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name force");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index force on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.force = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
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

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.damping = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autodestruct(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autodestruct");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autodestruct on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.autodestruct = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colorAnimation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorAnimation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorAnimation on a nil value");
			}
		}

		ParticleAnimator obj = (ParticleAnimator)o;
		obj.colorAnimation = LuaScriptMgr.GetNetObject<Color[]>(L, 3);
		return 0;
	}
}

