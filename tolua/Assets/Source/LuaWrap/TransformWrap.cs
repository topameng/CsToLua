using UnityEngine;
using System.Collections;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class TransformWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Translate", Translate),
		new LuaMethod("Rotate", Rotate),
		new LuaMethod("RotateAround", RotateAround),
		new LuaMethod("LookAt", LookAt),
		new LuaMethod("TransformDirection", TransformDirection),
		new LuaMethod("InverseTransformDirection", InverseTransformDirection),
		new LuaMethod("TransformPoint", TransformPoint),
		new LuaMethod("InverseTransformPoint", InverseTransformPoint),
		new LuaMethod("DetachChildren", DetachChildren),
		new LuaMethod("SetAsFirstSibling", SetAsFirstSibling),
		new LuaMethod("SetAsLastSibling", SetAsLastSibling),
		new LuaMethod("SetSiblingIndex", SetSiblingIndex),
		new LuaMethod("GetSiblingIndex", GetSiblingIndex),
		new LuaMethod("Find", Find),
		new LuaMethod("IsChildOf", IsChildOf),
		new LuaMethod("FindChild", FindChild),
		new LuaMethod("GetEnumerator", GetEnumerator),
		new LuaMethod("GetChild", GetChild),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("position", get_position, set_position),
		new LuaField("localPosition", get_localPosition, set_localPosition),
		new LuaField("eulerAngles", get_eulerAngles, set_eulerAngles),
		new LuaField("localEulerAngles", get_localEulerAngles, set_localEulerAngles),
		new LuaField("right", get_right, set_right),
		new LuaField("up", get_up, set_up),
		new LuaField("forward", get_forward, set_forward),
		new LuaField("rotation", get_rotation, set_rotation),
		new LuaField("localRotation", get_localRotation, set_localRotation),
		new LuaField("localScale", get_localScale, set_localScale),
		new LuaField("parent", get_parent, set_parent),
		new LuaField("worldToLocalMatrix", get_worldToLocalMatrix, null),
		new LuaField("localToWorldMatrix", get_localToWorldMatrix, null),
		new LuaField("root", get_root, null),
		new LuaField("childCount", get_childCount, null),
		new LuaField("lossyScale", get_lossyScale, null),
		new LuaField("hasChanged", get_hasChanged, set_hasChanged),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr l)
	{
		LuaDLL.luaL_error(l, "Transform class does not have a constructor function");
		return 0;
	}

	public void Register()
	{
		LuaMethod[] metas = new LuaMethod[]
		{
			new LuaMethod("__index", Lua_Index),
			new LuaMethod("__newindex", Lua_NewIndex),
		};

		luaMgr = LuaScriptMgr.Instance;
		reference = luaMgr.RegisterLib("Transform", regs);
		luaMgr.CreateMetaTable("Transform", metas, typeof(Transform));
		luaMgr.RegisterField(typeof(Transform), fields);
	}

	static bool get_position(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.position);
		return true;
	}

	static bool get_localPosition(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.localPosition);
		return true;
	}

	static bool get_eulerAngles(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.eulerAngles);
		return true;
	}

	static bool get_localEulerAngles(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.localEulerAngles);
		return true;
	}

	static bool get_right(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.right);
		return true;
	}

	static bool get_up(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.up);
		return true;
	}

	static bool get_forward(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.forward);
		return true;
	}

	static bool get_rotation(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.rotation);
		return true;
	}

	static bool get_localRotation(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.localRotation);
		return true;
	}

	static bool get_localScale(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.localScale);
		return true;
	}

	static bool get_parent(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.parent);
		return true;
	}

	static bool get_worldToLocalMatrix(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.worldToLocalMatrix);
		return true;
	}

	static bool get_localToWorldMatrix(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.localToWorldMatrix);
		return true;
	}

	static bool get_root(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.root);
		return true;
	}

	static bool get_childCount(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.childCount);
		return true;
	}

	static bool get_lossyScale(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.lossyScale);
		return true;
	}

	static bool get_hasChanged(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		luaMgr.PushResult(obj.hasChanged);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return ComponentWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Transform' does not contain a definition for '{0}'", str));
		return 0;
	}

	static bool set_position(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.position = (Vector3)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_localPosition(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.localPosition = (Vector3)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_eulerAngles(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.eulerAngles = (Vector3)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_localEulerAngles(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.localEulerAngles = (Vector3)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_right(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.right = (Vector3)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_up(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.up = (Vector3)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_forward(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.forward = (Vector3)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_rotation(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.rotation = (Quaternion)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_localRotation(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.localRotation = (Quaternion)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_localScale(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.localScale = (Vector3)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_parent(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.parent = (Transform)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_hasChanged(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Transform obj = (Transform)o;
		obj.hasChanged = luaMgr.GetBoolean(3);
		return true;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return ComponentWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Transform' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Translate(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(Transform), typeof(Vector3), typeof(Transform)};
		Type[] types2 = {typeof(Transform), typeof(Vector3), typeof(Space)};
		Type[] types4 = {typeof(Transform), typeof(float), typeof(float), typeof(float), typeof(Transform)};
		Type[] types5 = {typeof(Transform), typeof(float), typeof(float), typeof(float), typeof(Space)};

		if (count == 2)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			obj.Translate(arg0);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types1, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			Transform arg1 = (Transform)luaMgr.GetNetObject(3);
			obj.Translate(arg0,arg1);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types2, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			Space arg1 = (Space)luaMgr.GetNetObject(3);
			obj.Translate(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			obj.Translate(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5 && luaMgr.CheckTypes(types4, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			Transform arg3 = (Transform)luaMgr.GetNetObject(5);
			obj.Translate(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 5 && luaMgr.CheckTypes(types5, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			Space arg3 = (Space)luaMgr.GetNetObject(5);
			obj.Translate(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Transform.Translate' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Rotate(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(Transform), typeof(Vector3), typeof(float)};
		Type[] types2 = {typeof(Transform), typeof(Vector3), typeof(Space)};
		Type[] types3 = {typeof(Transform), typeof(Vector3), typeof(float), typeof(Space)};
		Type[] types4 = {typeof(Transform), typeof(float), typeof(float), typeof(float)};

		if (count == 2)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			obj.Rotate(arg0);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types1, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			obj.Rotate(arg0,arg1);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types2, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			Space arg1 = (Space)luaMgr.GetNetObject(3);
			obj.Rotate(arg0,arg1);
			return 0;
		}
		else if (count == 4 && luaMgr.CheckTypes(types3, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			Space arg2 = (Space)luaMgr.GetNetObject(4);
			obj.Rotate(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4 && luaMgr.CheckTypes(types4, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			obj.Rotate(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			Space arg3 = (Space)luaMgr.GetNetObject(5);
			obj.Rotate(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Transform.Rotate' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RotateAround(IntPtr l)
	{
		luaMgr.CheckArgsCount(4);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
		Vector3 arg1 = (Vector3)luaMgr.GetNetObject(3);
		float arg2 = (float)luaMgr.GetNumber(4);
		obj.RotateAround(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LookAt(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(Transform), typeof(Vector3)};
		Type[] types1 = {typeof(Transform), typeof(Transform)};
		Type[] types2 = {typeof(Transform), typeof(Vector3), typeof(Vector3)};
		Type[] types3 = {typeof(Transform), typeof(Transform), typeof(Vector3)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			obj.LookAt(arg0);
			return 0;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Transform arg0 = (Transform)luaMgr.GetNetObject(2);
			obj.LookAt(arg0);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types2, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			Vector3 arg1 = (Vector3)luaMgr.GetNetObject(3);
			obj.LookAt(arg0,arg1);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types3, 1))
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Transform arg0 = (Transform)luaMgr.GetNetObject(2);
			Vector3 arg1 = (Vector3)luaMgr.GetNetObject(3);
			obj.LookAt(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Transform.LookAt' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TransformDirection(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			Vector3 o = obj.TransformDirection(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			Vector3 o = obj.TransformDirection(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Transform.TransformDirection' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InverseTransformDirection(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			Vector3 o = obj.InverseTransformDirection(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			Vector3 o = obj.InverseTransformDirection(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Transform.InverseTransformDirection' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TransformPoint(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			Vector3 o = obj.TransformPoint(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			Vector3 o = obj.TransformPoint(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Transform.TransformPoint' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InverseTransformPoint(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			Vector3 arg0 = (Vector3)luaMgr.GetNetObject(2);
			Vector3 o = obj.InverseTransformPoint(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)luaMgr.GetNetObject(1);
			float arg0 = (float)luaMgr.GetNumber(2);
			float arg1 = (float)luaMgr.GetNumber(3);
			float arg2 = (float)luaMgr.GetNumber(4);
			Vector3 o = obj.InverseTransformPoint(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Transform.InverseTransformPoint' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DetachChildren(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		obj.DetachChildren();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAsFirstSibling(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		obj.SetAsFirstSibling();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAsLastSibling(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		obj.SetAsLastSibling();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSiblingIndex(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		int arg0 = (int)luaMgr.GetNumber(2);
		obj.SetSiblingIndex(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSiblingIndex(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		int o = obj.GetSiblingIndex();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Find(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		string arg0 = luaMgr.GetString(2);
		Transform o = obj.Find(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsChildOf(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		Transform arg0 = (Transform)luaMgr.GetNetObject(2);
		bool o = obj.IsChildOf(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindChild(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		string arg0 = luaMgr.GetString(2);
		Transform o = obj.FindChild(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		IEnumerator o = obj.GetEnumerator();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetChild(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Transform obj = (Transform)luaMgr.GetNetObject(1);
		int arg0 = (int)luaMgr.GetNumber(2);
		Transform o = obj.GetChild(arg0);
		luaMgr.PushResult(o);
		return 1;
	}
}

