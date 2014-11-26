using UnityEngine;
using System;
using LuaInterface;

public class JointWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateJoint),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("connectedBody", get_connectedBody, set_connectedBody),
		new LuaField("axis", get_axis, set_axis),
		new LuaField("anchor", get_anchor, set_anchor),
		new LuaField("connectedAnchor", get_connectedAnchor, set_connectedAnchor),
		new LuaField("autoConfigureConnectedAnchor", get_autoConfigureConnectedAnchor, set_autoConfigureConnectedAnchor),
		new LuaField("breakForce", get_breakForce, set_breakForce),
		new LuaField("breakTorque", get_breakTorque, set_breakTorque),
		new LuaField("enableCollision", get_enableCollision, set_enableCollision),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateJoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Joint obj = new Joint();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Joint.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Joint));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Joint", typeof(Joint), regs, fields, "UnityEngine.Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_connectedBody(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedBody");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedBody on a nil value");
			}
		}

		Joint obj = (Joint)o;
		LuaScriptMgr.Push(L, obj.connectedBody);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_axis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name axis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index axis on a nil value");
			}
		}

		Joint obj = (Joint)o;
		LuaScriptMgr.PushValue(L, obj.axis);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name anchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index anchor on a nil value");
			}
		}

		Joint obj = (Joint)o;
		LuaScriptMgr.PushValue(L, obj.anchor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_connectedAnchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedAnchor on a nil value");
			}
		}

		Joint obj = (Joint)o;
		LuaScriptMgr.PushValue(L, obj.connectedAnchor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autoConfigureConnectedAnchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoConfigureConnectedAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoConfigureConnectedAnchor on a nil value");
			}
		}

		Joint obj = (Joint)o;
		LuaScriptMgr.Push(L, obj.autoConfigureConnectedAnchor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_breakForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name breakForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index breakForce on a nil value");
			}
		}

		Joint obj = (Joint)o;
		LuaScriptMgr.Push(L, obj.breakForce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_breakTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name breakTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index breakTorque on a nil value");
			}
		}

		Joint obj = (Joint)o;
		LuaScriptMgr.Push(L, obj.breakTorque);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableCollision(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableCollision");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableCollision on a nil value");
			}
		}

		Joint obj = (Joint)o;
		LuaScriptMgr.Push(L, obj.enableCollision);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_connectedBody(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedBody");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedBody on a nil value");
			}
		}

		Joint obj = (Joint)o;
		obj.connectedBody = LuaScriptMgr.GetNetObject<Rigidbody>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_axis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name axis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index axis on a nil value");
			}
		}

		Joint obj = (Joint)o;
		obj.axis = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name anchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index anchor on a nil value");
			}
		}

		Joint obj = (Joint)o;
		obj.anchor = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_connectedAnchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedAnchor on a nil value");
			}
		}

		Joint obj = (Joint)o;
		obj.connectedAnchor = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autoConfigureConnectedAnchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoConfigureConnectedAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoConfigureConnectedAnchor on a nil value");
			}
		}

		Joint obj = (Joint)o;
		obj.autoConfigureConnectedAnchor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_breakForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name breakForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index breakForce on a nil value");
			}
		}

		Joint obj = (Joint)o;
		obj.breakForce = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_breakTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name breakTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index breakTorque on a nil value");
			}
		}

		Joint obj = (Joint)o;
		obj.breakTorque = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableCollision(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableCollision");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableCollision on a nil value");
			}
		}

		Joint obj = (Joint)o;
		obj.enableCollision = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

