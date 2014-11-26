using UnityEngine;
using System;
using LuaInterface;

public class ProceduralPropertyDescriptionWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateProceduralPropertyDescription),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("name", get_name, set_name),
		new LuaField("label", get_label, set_label),
		new LuaField("group", get_group, set_group),
		new LuaField("type", get_type, set_type),
		new LuaField("hasRange", get_hasRange, set_hasRange),
		new LuaField("minimum", get_minimum, set_minimum),
		new LuaField("maximum", get_maximum, set_maximum),
		new LuaField("step", get_step, set_step),
		new LuaField("enumOptions", get_enumOptions, set_enumOptions),
		new LuaField("componentLabels", get_componentLabels, set_componentLabels),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateProceduralPropertyDescription(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ProceduralPropertyDescription obj = new ProceduralPropertyDescription();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ProceduralPropertyDescription.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ProceduralPropertyDescription));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ProceduralPropertyDescription", typeof(ProceduralPropertyDescription), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.Push(L, obj.name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_label(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name label");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index label on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.Push(L, obj.label);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.Push(L, obj.group);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.PushEnum(L, obj.type);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasRange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hasRange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hasRange on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.Push(L, obj.hasRange);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minimum(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minimum");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minimum on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.Push(L, obj.minimum);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximum(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maximum");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maximum on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.Push(L, obj.maximum);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_step(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name step");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index step on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.Push(L, obj.step);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enumOptions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enumOptions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enumOptions on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.PushArray(L, obj.enumOptions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_componentLabels(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name componentLabels");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index componentLabels on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		LuaScriptMgr.PushArray(L, obj.componentLabels);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_label(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name label");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index label on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.label = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.group = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.type = LuaScriptMgr.GetNetObject<ProceduralPropertyType>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hasRange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hasRange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hasRange on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.hasRange = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_minimum(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minimum");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minimum on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.minimum = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximum(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maximum");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maximum on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.maximum = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_step(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name step");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index step on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.step = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enumOptions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enumOptions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enumOptions on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.enumOptions = LuaScriptMgr.GetNetObject<String[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_componentLabels(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name componentLabels");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index componentLabels on a nil value");
			}
		}

		ProceduralPropertyDescription obj = (ProceduralPropertyDescription)o;
		obj.componentLabels = LuaScriptMgr.GetNetObject<String[]>(L, 3);
		return 0;
	}
}

