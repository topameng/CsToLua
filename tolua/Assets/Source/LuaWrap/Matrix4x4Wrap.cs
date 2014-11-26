using UnityEngine;
using System;
using LuaInterface;

public class Matrix4x4Wrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("set_Item", set_Item),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Equals", Equals),
		new LuaMethod("Inverse", Inverse),
		new LuaMethod("Transpose", Transpose),
		new LuaMethod("GetColumn", GetColumn),
		new LuaMethod("GetRow", GetRow),
		new LuaMethod("SetColumn", SetColumn),
		new LuaMethod("SetRow", SetRow),
		new LuaMethod("MultiplyPoint", MultiplyPoint),
		new LuaMethod("MultiplyPoint3x4", MultiplyPoint3x4),
		new LuaMethod("MultiplyVector", MultiplyVector),
		new LuaMethod("Scale", Scale),
		new LuaMethod("SetTRS", SetTRS),
		new LuaMethod("TRS", TRS),
		new LuaMethod("ToString", ToString),
		new LuaMethod("Ortho", Ortho),
		new LuaMethod("Perspective", Perspective),
		new LuaMethod("New", _CreateMatrix4x4),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
		new LuaMethod("__mul", Lua_Mul),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("m00", get_m00, set_m00),
		new LuaField("m10", get_m10, set_m10),
		new LuaField("m20", get_m20, set_m20),
		new LuaField("m30", get_m30, set_m30),
		new LuaField("m01", get_m01, set_m01),
		new LuaField("m11", get_m11, set_m11),
		new LuaField("m21", get_m21, set_m21),
		new LuaField("m31", get_m31, set_m31),
		new LuaField("m02", get_m02, set_m02),
		new LuaField("m12", get_m12, set_m12),
		new LuaField("m22", get_m22, set_m22),
		new LuaField("m32", get_m32, set_m32),
		new LuaField("m03", get_m03, set_m03),
		new LuaField("m13", get_m13, set_m13),
		new LuaField("m23", get_m23, set_m23),
		new LuaField("m33", get_m33, set_m33),
		new LuaField("inverse", get_inverse, null),
		new LuaField("transpose", get_transpose, null),
		new LuaField("isIdentity", get_isIdentity, null),
		new LuaField("zero", get_zero, null),
		new LuaField("identity", get_identity, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMatrix4x4(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Matrix4x4 obj = new Matrix4x4();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Matrix4x4));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Matrix4x4", typeof(Matrix4x4), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m00(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m00");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m00 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m00);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m10(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m10");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m10 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m10);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m20(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m20");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m20 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m20);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m30(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m30");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m30 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m30);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m01(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m01");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m01 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m01);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m11(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m11");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m11 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m11);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m21(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m21");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m21 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m21);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m31(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m31");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m31 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m31);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m02(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m02");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m02 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m02);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m12(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m12");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m12 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m12);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m22(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m22");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m22 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m22);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m32(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m32");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m32 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m32);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m03(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m03");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m03 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m03);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m13(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m13");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m13 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m13);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m23(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m23");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m23 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m23);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m33(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m33");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m33 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.m33);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inverse(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name inverse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index inverse on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.PushValue(L, obj.inverse);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transpose(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name transpose");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index transpose on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.PushValue(L, obj.transpose);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isIdentity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isIdentity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isIdentity on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		LuaScriptMgr.Push(L, obj.isIdentity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_zero(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Matrix4x4.zero);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_identity(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Matrix4x4.identity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m00(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m00");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m00 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m00 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m10(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m10");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m10 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m10 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m20(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m20");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m20 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m20 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m30(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m30");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m30 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m30 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m01(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m01");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m01 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m01 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m11(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m11");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m11 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m11 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m21(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m21");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m21 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m21 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m31(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m31");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m31 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m31 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m02(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m02");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m02 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m02 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m12(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m12");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m12 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m12 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m22(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m22");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m22 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m22 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m32(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m32");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m32 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m32 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m03(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m03");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m03 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m03 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m13(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m13");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m13 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m13 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m23(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m23");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m23 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m23 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m33(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name m33");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index m33 on a nil value");
			}
		}

		Matrix4x4 obj = (Matrix4x4)o;
		obj.m33 = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = LuaScriptMgr.GetLuaObject(L, 1);
		if (obj != null)
		{
			LuaScriptMgr.Push(L, obj.ToString());
		}
		else
		{
			LuaScriptMgr.Push(L, "Table: UnityEngine.Matrix4x4");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			float o = obj[arg0];
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			float o = obj[arg0,arg1];
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Matrix4x4.get_Item");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Item(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj[arg0] = arg1;
			LuaScriptMgr.SetValueObject(L, 1, obj);
			return 0;
		}
		else if (count == 4)
		{
			Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj[arg0, arg1] = arg2;
			LuaScriptMgr.SetValueObject(L, 1, obj);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Matrix4x4.set_Item");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Inverse(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Matrix4x4 arg0 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		Matrix4x4 o = Matrix4x4.Inverse(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Transpose(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Matrix4x4 arg0 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		Matrix4x4 o = Matrix4x4.Transpose(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetColumn(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Vector4 o = obj.GetColumn(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRow(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Vector4 o = obj.GetRow(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetColumn(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 3);
		obj.SetColumn(arg0,arg1);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetRow(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 3);
		obj.SetRow(arg0,arg1);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MultiplyPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.MultiplyPoint(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MultiplyPoint3x4(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.MultiplyPoint3x4(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MultiplyVector(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.MultiplyVector(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Scale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
		Matrix4x4 o = Matrix4x4.Scale(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTRS(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 3);
		Vector3 arg2 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
		obj.SetTRS(arg0,arg1,arg2);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TRS(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
		Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
		Vector3 arg2 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		Matrix4x4 o = Matrix4x4.TRS(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Matrix4x4 obj = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Matrix4x4.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Ortho(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
		Matrix4x4 o = Matrix4x4.Ortho(arg0,arg1,arg2,arg3,arg4,arg5);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Perspective(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		Matrix4x4 o = Matrix4x4.Perspective(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Mul(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Matrix4x4), typeof(Vector4)};
		Type[] types1 = {typeof(Matrix4x4), typeof(Matrix4x4)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Matrix4x4 arg0 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
			Vector4 o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Matrix4x4 arg0 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			Matrix4x4 arg1 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 2);
			Matrix4x4 o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Matrix4x4.op_Multiply");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Matrix4x4 arg0 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
		Matrix4x4 arg1 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

