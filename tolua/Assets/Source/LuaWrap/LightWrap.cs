using UnityEngine;
using System;
using LuaInterface;

public class LightWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetLights", GetLights),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("type", get_type, set_type),
		new LuaField("color", get_color, set_color),
		new LuaField("intensity", get_intensity, set_intensity),
		new LuaField("shadows", get_shadows, set_shadows),
		new LuaField("shadowStrength", get_shadowStrength, set_shadowStrength),
		new LuaField("shadowBias", get_shadowBias, set_shadowBias),
		new LuaField("shadowSoftness", get_shadowSoftness, set_shadowSoftness),
		new LuaField("shadowSoftnessFade", get_shadowSoftnessFade, set_shadowSoftnessFade),
		new LuaField("range", get_range, set_range),
		new LuaField("spotAngle", get_spotAngle, set_spotAngle),
		new LuaField("cookieSize", get_cookieSize, set_cookieSize),
		new LuaField("cookie", get_cookie, set_cookie),
		new LuaField("flare", get_flare, set_flare),
		new LuaField("renderMode", get_renderMode, set_renderMode),
		new LuaField("alreadyLightmapped", get_alreadyLightmapped, set_alreadyLightmapped),
		new LuaField("cullingMask", get_cullingMask, set_cullingMask),
		new LuaField("areaSize", get_areaSize, set_areaSize),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Light obj = new Light();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Light.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Light));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Light", typeof(Light), regs, fields, "Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name type");
		}

		Light obj = (Light)o;
		LuaScriptMgr.PushEnum(L, obj.type);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_color(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name color");
		}

		Light obj = (Light)o;
		LuaScriptMgr.PushValue(L, obj.color);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_intensity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name intensity");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.intensity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadows(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadows");
		}

		Light obj = (Light)o;
		LuaScriptMgr.PushEnum(L, obj.shadows);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowStrength(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadowStrength");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.shadowStrength);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowBias(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadowBias");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.shadowBias);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowSoftness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadowSoftness");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.shadowSoftness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowSoftnessFade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadowSoftnessFade");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.shadowSoftnessFade);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_range(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name range");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.range);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spotAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name spotAngle");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.spotAngle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cookieSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name cookieSize");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.cookieSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cookie(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name cookie");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.cookie);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flare(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name flare");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.flare);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name renderMode");
		}

		Light obj = (Light)o;
		LuaScriptMgr.PushEnum(L, obj.renderMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_alreadyLightmapped(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name alreadyLightmapped");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.alreadyLightmapped);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cullingMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name cullingMask");
		}

		Light obj = (Light)o;
		LuaScriptMgr.Push(L, obj.cullingMask);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_areaSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name areaSize");
		}

		Light obj = (Light)o;
		LuaScriptMgr.PushValue(L, obj.areaSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name type");
		}

		Light obj = (Light)o;
		obj.type = LuaScriptMgr.GetNetObject<LightType>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_color(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name color");
		}

		Light obj = (Light)o;
		obj.color = LuaScriptMgr.GetNetObject<Color>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_intensity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name intensity");
		}

		Light obj = (Light)o;
		obj.intensity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadows(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadows");
		}

		Light obj = (Light)o;
		obj.shadows = LuaScriptMgr.GetNetObject<LightShadows>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowStrength(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadowStrength");
		}

		Light obj = (Light)o;
		obj.shadowStrength = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowBias(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadowBias");
		}

		Light obj = (Light)o;
		obj.shadowBias = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowSoftness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadowSoftness");
		}

		Light obj = (Light)o;
		obj.shadowSoftness = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowSoftnessFade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name shadowSoftnessFade");
		}

		Light obj = (Light)o;
		obj.shadowSoftnessFade = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_range(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name range");
		}

		Light obj = (Light)o;
		obj.range = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spotAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name spotAngle");
		}

		Light obj = (Light)o;
		obj.spotAngle = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cookieSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name cookieSize");
		}

		Light obj = (Light)o;
		obj.cookieSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cookie(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name cookie");
		}

		Light obj = (Light)o;
		obj.cookie = LuaScriptMgr.GetNetObject<Texture>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flare(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name flare");
		}

		Light obj = (Light)o;
		obj.flare = LuaScriptMgr.GetNetObject<Flare>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name renderMode");
		}

		Light obj = (Light)o;
		obj.renderMode = LuaScriptMgr.GetNetObject<LightRenderMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_alreadyLightmapped(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name alreadyLightmapped");
		}

		Light obj = (Light)o;
		obj.alreadyLightmapped = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cullingMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name cullingMask");
		}

		Light obj = (Light)o;
		obj.cullingMask = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_areaSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name areaSize");
		}

		Light obj = (Light)o;
		obj.areaSize = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLights(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LightType arg0 = LuaScriptMgr.GetNetObject<LightType>(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		Light[] o = Light.GetLights(arg0,arg1);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}
}

