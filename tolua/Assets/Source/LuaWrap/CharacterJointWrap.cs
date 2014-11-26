using UnityEngine;
using System;
using LuaInterface;

public class CharacterJointWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateCharacterJoint),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("swingAxis", get_swingAxis, set_swingAxis),
		new LuaField("lowTwistLimit", get_lowTwistLimit, set_lowTwistLimit),
		new LuaField("highTwistLimit", get_highTwistLimit, set_highTwistLimit),
		new LuaField("swing1Limit", get_swing1Limit, set_swing1Limit),
		new LuaField("swing2Limit", get_swing2Limit, set_swing2Limit),
		new LuaField("targetRotation", get_targetRotation, set_targetRotation),
		new LuaField("targetAngularVelocity", get_targetAngularVelocity, set_targetAngularVelocity),
		new LuaField("rotationDrive", get_rotationDrive, set_rotationDrive),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCharacterJoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CharacterJoint obj = new CharacterJoint();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CharacterJoint.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(CharacterJoint));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.CharacterJoint", typeof(CharacterJoint), regs, fields, "UnityEngine.Joint");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_swingAxis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name swingAxis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index swingAxis on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		LuaScriptMgr.PushValue(L, obj.swingAxis);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lowTwistLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowTwistLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowTwistLimit on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		LuaScriptMgr.PushValue(L, obj.lowTwistLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_highTwistLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name highTwistLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index highTwistLimit on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		LuaScriptMgr.PushValue(L, obj.highTwistLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_swing1Limit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name swing1Limit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index swing1Limit on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		LuaScriptMgr.PushValue(L, obj.swing1Limit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_swing2Limit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name swing2Limit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index swing2Limit on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		LuaScriptMgr.PushValue(L, obj.swing2Limit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetRotation on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		LuaScriptMgr.PushValue(L, obj.targetRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetAngularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetAngularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetAngularVelocity on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		LuaScriptMgr.PushValue(L, obj.targetAngularVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationDrive on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		LuaScriptMgr.PushValue(L, obj.rotationDrive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_swingAxis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name swingAxis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index swingAxis on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		obj.swingAxis = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lowTwistLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowTwistLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowTwistLimit on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		obj.lowTwistLimit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_highTwistLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name highTwistLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index highTwistLimit on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		obj.highTwistLimit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_swing1Limit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name swing1Limit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index swing1Limit on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		obj.swing1Limit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_swing2Limit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name swing2Limit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index swing2Limit on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		obj.swing2Limit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetRotation on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		obj.targetRotation = LuaScriptMgr.GetNetObject<Quaternion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetAngularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetAngularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetAngularVelocity on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		obj.targetAngularVelocity = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotationDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationDrive on a nil value");
			}
		}

		CharacterJoint obj = (CharacterJoint)o;
		obj.rotationDrive = LuaScriptMgr.GetNetObject<JointDrive>(L, 3);
		return 0;
	}
}

