using UnityEngine;
using System;
using LuaInterface;

public class ParticleSystemRendererWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateParticleSystemRenderer),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("renderMode", get_renderMode, set_renderMode),
		new LuaField("lengthScale", get_lengthScale, set_lengthScale),
		new LuaField("velocityScale", get_velocityScale, set_velocityScale),
		new LuaField("cameraVelocityScale", get_cameraVelocityScale, set_cameraVelocityScale),
		new LuaField("maxParticleSize", get_maxParticleSize, set_maxParticleSize),
		new LuaField("mesh", get_mesh, set_mesh),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateParticleSystemRenderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ParticleSystemRenderer obj = new ParticleSystemRenderer();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystemRenderer.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ParticleSystemRenderer));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleSystemRenderer", typeof(ParticleSystemRenderer), regs, fields, "UnityEngine.Renderer");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderMode on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		LuaScriptMgr.PushEnum(L, obj.renderMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lengthScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lengthScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lengthScale on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		LuaScriptMgr.Push(L, obj.lengthScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocityScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name velocityScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index velocityScale on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		LuaScriptMgr.Push(L, obj.velocityScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraVelocityScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cameraVelocityScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cameraVelocityScale on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		LuaScriptMgr.Push(L, obj.cameraVelocityScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxParticleSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxParticleSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxParticleSize on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		LuaScriptMgr.Push(L, obj.maxParticleSize);
		return 1;
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

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		LuaScriptMgr.Push(L, obj.mesh);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderMode on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		obj.renderMode = LuaScriptMgr.GetNetObject<ParticleSystemRenderMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lengthScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lengthScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lengthScale on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		obj.lengthScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocityScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name velocityScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index velocityScale on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		obj.velocityScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraVelocityScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cameraVelocityScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cameraVelocityScale on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		obj.cameraVelocityScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxParticleSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxParticleSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxParticleSize on a nil value");
			}
		}

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		obj.maxParticleSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
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

		ParticleSystemRenderer obj = (ParticleSystemRenderer)o;
		obj.mesh = LuaScriptMgr.GetNetObject<Mesh>(L, 3);
		return 0;
	}
}

