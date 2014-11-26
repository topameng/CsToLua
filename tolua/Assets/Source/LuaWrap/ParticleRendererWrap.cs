using UnityEngine;
using System;
using LuaInterface;

public class ParticleRendererWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateParticleRenderer),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("particleRenderMode", get_particleRenderMode, set_particleRenderMode),
		new LuaField("lengthScale", get_lengthScale, set_lengthScale),
		new LuaField("velocityScale", get_velocityScale, set_velocityScale),
		new LuaField("cameraVelocityScale", get_cameraVelocityScale, set_cameraVelocityScale),
		new LuaField("maxParticleSize", get_maxParticleSize, set_maxParticleSize),
		new LuaField("uvAnimationXTile", get_uvAnimationXTile, set_uvAnimationXTile),
		new LuaField("uvAnimationYTile", get_uvAnimationYTile, set_uvAnimationYTile),
		new LuaField("uvAnimationCycles", get_uvAnimationCycles, set_uvAnimationCycles),
		new LuaField("maxPartileSize", get_maxPartileSize, set_maxPartileSize),
		new LuaField("uvTiles", get_uvTiles, set_uvTiles),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateParticleRenderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ParticleRenderer obj = new ParticleRenderer();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleRenderer.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ParticleRenderer));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleRenderer", typeof(ParticleRenderer), regs, fields, "UnityEngine.Renderer");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_particleRenderMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name particleRenderMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index particleRenderMode on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		LuaScriptMgr.PushEnum(L, obj.particleRenderMode);
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

		ParticleRenderer obj = (ParticleRenderer)o;
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

		ParticleRenderer obj = (ParticleRenderer)o;
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

		ParticleRenderer obj = (ParticleRenderer)o;
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

		ParticleRenderer obj = (ParticleRenderer)o;
		LuaScriptMgr.Push(L, obj.maxParticleSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uvAnimationXTile(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvAnimationXTile");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvAnimationXTile on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		LuaScriptMgr.Push(L, obj.uvAnimationXTile);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uvAnimationYTile(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvAnimationYTile");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvAnimationYTile on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		LuaScriptMgr.Push(L, obj.uvAnimationYTile);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uvAnimationCycles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvAnimationCycles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvAnimationCycles on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		LuaScriptMgr.Push(L, obj.uvAnimationCycles);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxPartileSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxPartileSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxPartileSize on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		LuaScriptMgr.Push(L, obj.maxPartileSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uvTiles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvTiles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvTiles on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		LuaScriptMgr.PushArray(L, obj.uvTiles);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_particleRenderMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name particleRenderMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index particleRenderMode on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		obj.particleRenderMode = LuaScriptMgr.GetNetObject<ParticleRenderMode>(L, 3);
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

		ParticleRenderer obj = (ParticleRenderer)o;
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

		ParticleRenderer obj = (ParticleRenderer)o;
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

		ParticleRenderer obj = (ParticleRenderer)o;
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

		ParticleRenderer obj = (ParticleRenderer)o;
		obj.maxParticleSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uvAnimationXTile(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvAnimationXTile");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvAnimationXTile on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		obj.uvAnimationXTile = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uvAnimationYTile(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvAnimationYTile");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvAnimationYTile on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		obj.uvAnimationYTile = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uvAnimationCycles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvAnimationCycles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvAnimationCycles on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		obj.uvAnimationCycles = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxPartileSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxPartileSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxPartileSize on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		obj.maxPartileSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uvTiles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvTiles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvTiles on a nil value");
			}
		}

		ParticleRenderer obj = (ParticleRenderer)o;
		obj.uvTiles = LuaScriptMgr.GetNetObject<Rect[]>(L, 3);
		return 0;
	}
}

