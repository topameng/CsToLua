using UnityEngine;
using System;
using LuaInterface;

public class HumanDescriptionWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateHumanDescription),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("human", get_human, set_human),
		new LuaField("skeleton", get_skeleton, set_skeleton),
		new LuaField("upperArmTwist", get_upperArmTwist, set_upperArmTwist),
		new LuaField("lowerArmTwist", get_lowerArmTwist, set_lowerArmTwist),
		new LuaField("upperLegTwist", get_upperLegTwist, set_upperLegTwist),
		new LuaField("lowerLegTwist", get_lowerLegTwist, set_lowerLegTwist),
		new LuaField("armStretch", get_armStretch, set_armStretch),
		new LuaField("legStretch", get_legStretch, set_legStretch),
		new LuaField("feetSpacing", get_feetSpacing, set_feetSpacing),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateHumanDescription(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		HumanDescription obj = new HumanDescription();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(HumanDescription));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.HumanDescription", typeof(HumanDescription), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_human(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name human");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index human on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.PushArray(L, obj.human);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skeleton(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skeleton");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skeleton on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.PushArray(L, obj.skeleton);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_upperArmTwist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name upperArmTwist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index upperArmTwist on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.Push(L, obj.upperArmTwist);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lowerArmTwist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowerArmTwist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowerArmTwist on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.Push(L, obj.lowerArmTwist);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_upperLegTwist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name upperLegTwist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index upperLegTwist on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.Push(L, obj.upperLegTwist);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lowerLegTwist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowerLegTwist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowerLegTwist on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.Push(L, obj.lowerLegTwist);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_armStretch(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name armStretch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index armStretch on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.Push(L, obj.armStretch);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legStretch(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legStretch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legStretch on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.Push(L, obj.legStretch);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_feetSpacing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name feetSpacing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index feetSpacing on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		LuaScriptMgr.Push(L, obj.feetSpacing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_human(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name human");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index human on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.human = LuaScriptMgr.GetNetObject<HumanBone[]>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skeleton(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skeleton");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skeleton on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.skeleton = LuaScriptMgr.GetNetObject<SkeletonBone[]>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_upperArmTwist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name upperArmTwist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index upperArmTwist on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.upperArmTwist = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lowerArmTwist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowerArmTwist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowerArmTwist on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.lowerArmTwist = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_upperLegTwist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name upperLegTwist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index upperLegTwist on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.upperLegTwist = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lowerLegTwist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowerLegTwist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowerLegTwist on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.lowerLegTwist = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_armStretch(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name armStretch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index armStretch on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.armStretch = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legStretch(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legStretch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legStretch on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.legStretch = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_feetSpacing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name feetSpacing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index feetSpacing on a nil value");
			}
		}

		HumanDescription obj = (HumanDescription)o;
		obj.feetSpacing = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

