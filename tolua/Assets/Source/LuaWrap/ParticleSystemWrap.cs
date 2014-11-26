using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ParticleSystemWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetParticles", SetParticles),
		new LuaMethod("GetParticles", GetParticles),
		new LuaMethod("GetCollisionEvents", GetCollisionEvents),
		new LuaMethod("Simulate", Simulate),
		new LuaMethod("Play", Play),
		new LuaMethod("Stop", Stop),
		new LuaMethod("Pause", Pause),
		new LuaMethod("Clear", Clear),
		new LuaMethod("IsAlive", IsAlive),
		new LuaMethod("Emit", Emit),
		new LuaMethod("New", _CreateParticleSystem),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("startDelay", get_startDelay, set_startDelay),
		new LuaField("isPlaying", get_isPlaying, null),
		new LuaField("isStopped", get_isStopped, null),
		new LuaField("isPaused", get_isPaused, null),
		new LuaField("loop", get_loop, set_loop),
		new LuaField("playOnAwake", get_playOnAwake, set_playOnAwake),
		new LuaField("time", get_time, set_time),
		new LuaField("duration", get_duration, null),
		new LuaField("playbackSpeed", get_playbackSpeed, set_playbackSpeed),
		new LuaField("particleCount", get_particleCount, null),
		new LuaField("safeCollisionEventSize", get_safeCollisionEventSize, null),
		new LuaField("enableEmission", get_enableEmission, set_enableEmission),
		new LuaField("emissionRate", get_emissionRate, set_emissionRate),
		new LuaField("startSpeed", get_startSpeed, set_startSpeed),
		new LuaField("startSize", get_startSize, set_startSize),
		new LuaField("startColor", get_startColor, set_startColor),
		new LuaField("startRotation", get_startRotation, set_startRotation),
		new LuaField("startLifetime", get_startLifetime, set_startLifetime),
		new LuaField("gravityModifier", get_gravityModifier, set_gravityModifier),
		new LuaField("maxParticles", get_maxParticles, set_maxParticles),
		new LuaField("simulationSpace", get_simulationSpace, set_simulationSpace),
		new LuaField("randomSeed", get_randomSeed, set_randomSeed),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateParticleSystem(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ParticleSystem obj = new ParticleSystem();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ParticleSystem));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleSystem", typeof(ParticleSystem), regs, fields, "UnityEngine.Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startDelay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startDelay on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.startDelay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPlaying");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPlaying on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.isPlaying);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isStopped(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isStopped");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isStopped on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.isStopped);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPaused(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPaused");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPaused on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.isPaused);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loop on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.loop);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playOnAwake(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playOnAwake");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playOnAwake on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.playOnAwake);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_duration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name duration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index duration on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.duration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playbackSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playbackSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playbackSpeed on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.playbackSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_particleCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name particleCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index particleCount on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.particleCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_safeCollisionEventSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name safeCollisionEventSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index safeCollisionEventSize on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.safeCollisionEventSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableEmission(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableEmission");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableEmission on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.enableEmission);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_emissionRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name emissionRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index emissionRate on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.emissionRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startSpeed on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.startSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startSize on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.startSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startColor on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.PushValue(L, obj.startColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startRotation on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.startRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startLifetime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startLifetime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startLifetime on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.startLifetime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gravityModifier(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gravityModifier");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gravityModifier on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.gravityModifier);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxParticles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxParticles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxParticles on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.maxParticles);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_simulationSpace(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name simulationSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index simulationSpace on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.PushEnum(L, obj.simulationSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_randomSeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name randomSeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index randomSeed on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		LuaScriptMgr.Push(L, obj.randomSeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startDelay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startDelay on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.startDelay = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_loop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loop on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.loop = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_playOnAwake(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playOnAwake");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playOnAwake on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.playOnAwake = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.time = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_playbackSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playbackSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playbackSpeed on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.playbackSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableEmission(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableEmission");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableEmission on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.enableEmission = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_emissionRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name emissionRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index emissionRate on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.emissionRate = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startSpeed on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.startSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startSize on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.startSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startColor on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.startColor = LuaScriptMgr.GetNetObject<Color>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startRotation on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.startRotation = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startLifetime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startLifetime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startLifetime on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.startLifetime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gravityModifier(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gravityModifier");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gravityModifier on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.gravityModifier = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxParticles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxParticles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxParticles on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.maxParticles = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_simulationSpace(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name simulationSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index simulationSpace on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.simulationSpace = LuaScriptMgr.GetNetObject<ParticleSystemSimulationSpace>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_randomSeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name randomSeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index randomSeed on a nil value");
			}
		}

		ParticleSystem obj = (ParticleSystem)o;
		obj.randomSeed = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetParticles(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
		UnityEngine.ParticleSystem.Particle[] objs0 = LuaScriptMgr.GetArrayObject<UnityEngine.ParticleSystem.Particle>(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.SetParticles(objs0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetParticles(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
		UnityEngine.ParticleSystem.Particle[] objs0 = LuaScriptMgr.GetArrayObject<UnityEngine.ParticleSystem.Particle>(L, 2);
		int o = obj.GetParticles(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCollisionEvents(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
		UnityEngine.ParticleSystem.CollisionEvent[] objs1 = LuaScriptMgr.GetArrayObject<UnityEngine.ParticleSystem.CollisionEvent>(L, 3);
		int o = obj.GetCollisionEvents(arg0,objs1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Simulate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			obj.Simulate(arg0);
			return 0;
		}
		else if (count == 3)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.Simulate(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			obj.Simulate(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Simulate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			obj.Play();
			return 0;
		}
		else if (count == 2)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Play(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Play");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			obj.Stop();
			return 0;
		}
		else if (count == 2)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Stop(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Stop");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			obj.Pause();
			return 0;
		}
		else if (count == 2)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Pause(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Pause");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			obj.Clear();
			return 0;
		}
		else if (count == 2)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Clear(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Clear");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsAlive(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			bool o = obj.IsAlive();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			bool o = obj.IsAlive(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.IsAlive");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Emit(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(ParticleSystem), typeof(UnityEngine.ParticleSystem.Particle)};
		Type[] types1 = {typeof(ParticleSystem), typeof(int)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			UnityEngine.ParticleSystem.Particle arg0 = LuaScriptMgr.GetNetObject<UnityEngine.ParticleSystem.Particle>(L, 2);
			obj.Emit(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			obj.Emit(arg0);
			return 0;
		}
		else if (count == 6)
		{
			ParticleSystem obj = LuaScriptMgr.GetNetObject<ParticleSystem>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
			Color32 arg4 = LuaScriptMgr.GetNetObject<Color32>(L, 6);
			obj.Emit(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Emit");
		}

		return 0;
	}
}

