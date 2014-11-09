using UnityEngine;
using System;
using System.Collections;
using LuaInterface;

public class TransformWrap
{
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
		new LuaMethod("GetClassType", GetClassType),
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
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Transform class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Transform));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Transform", typeof(Transform), regs, fields, "Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_position(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name position");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.position);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localPosition");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.localPosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_eulerAngles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name eulerAngles");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.eulerAngles);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localEulerAngles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localEulerAngles");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.localEulerAngles);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_right(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name right");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.right);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_up(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name up");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.up);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_forward(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name forward");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.forward);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name rotation");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.rotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localRotation");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.localRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localScale");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.localScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_parent(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name parent");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.Push(L, obj.parent);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldToLocalMatrix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name worldToLocalMatrix");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.worldToLocalMatrix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localToWorldMatrix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localToWorldMatrix");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.localToWorldMatrix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_root(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name root");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.Push(L, obj.root);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_childCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name childCount");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.Push(L, obj.childCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lossyScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name lossyScale");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.PushValue(L, obj.lossyScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasChanged(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name hasChanged");
		}

		Transform obj = (Transform)o;
		LuaScriptMgr.Push(L, obj.hasChanged);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_position(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name position");
		}

		Transform obj = (Transform)o;
		obj.position = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localPosition");
		}

		Transform obj = (Transform)o;
		obj.localPosition = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_eulerAngles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name eulerAngles");
		}

		Transform obj = (Transform)o;
		obj.eulerAngles = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localEulerAngles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localEulerAngles");
		}

		Transform obj = (Transform)o;
		obj.localEulerAngles = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_right(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name right");
		}

		Transform obj = (Transform)o;
		obj.right = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_up(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name up");
		}

		Transform obj = (Transform)o;
		obj.up = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_forward(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name forward");
		}

		Transform obj = (Transform)o;
		obj.forward = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name rotation");
		}

		Transform obj = (Transform)o;
		obj.rotation = (Quaternion)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localRotation");
		}

		Transform obj = (Transform)o;
		obj.localRotation = (Quaternion)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localScale");
		}

		Transform obj = (Transform)o;
		obj.localScale = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_parent(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name parent");
		}

		Transform obj = (Transform)o;
		obj.parent = (Transform)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hasChanged(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name hasChanged");
		}

		Transform obj = (Transform)o;
		obj.hasChanged = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Translate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Transform), typeof(Vector3), typeof(Transform)};
		Type[] types2 = {typeof(Transform), typeof(Vector3), typeof(Space)};
		Type[] types4 = {typeof(Transform), typeof(float), typeof(float), typeof(float), typeof(Transform)};
		Type[] types5 = {typeof(Transform), typeof(float), typeof(float), typeof(float), typeof(Space)};

		if (count == 2)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			obj.Translate(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Transform arg1 = (Transform)LuaScriptMgr.GetNetObject(L, 3);
			obj.Translate(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Space arg1 = (Space)LuaScriptMgr.GetNumber(L, 3);
			obj.Translate(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.Translate(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			Transform arg3 = (Transform)LuaScriptMgr.GetNetObject(L, 5);
			obj.Translate(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, types5, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			Space arg3 = (Space)LuaScriptMgr.GetNumber(L, 5);
			obj.Translate(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Transform.Translate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Rotate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Transform), typeof(Vector3), typeof(float)};
		Type[] types2 = {typeof(Transform), typeof(Vector3), typeof(Space)};
		Type[] types3 = {typeof(Transform), typeof(Vector3), typeof(float), typeof(Space)};
		Type[] types4 = {typeof(Transform), typeof(float), typeof(float), typeof(float)};

		if (count == 2)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			obj.Rotate(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.Rotate(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Space arg1 = (Space)LuaScriptMgr.GetNumber(L, 3);
			obj.Rotate(arg0,arg1);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			Space arg2 = (Space)LuaScriptMgr.GetNumber(L, 4);
			obj.Rotate(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.Rotate(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			Space arg3 = (Space)LuaScriptMgr.GetNumber(L, 5);
			obj.Rotate(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Transform.Rotate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RotateAround(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
		Vector3 arg1 = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		obj.RotateAround(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LookAt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Transform), typeof(Vector3)};
		Type[] types1 = {typeof(Transform), typeof(Transform)};
		Type[] types2 = {typeof(Transform), typeof(Vector3), typeof(Vector3)};
		Type[] types3 = {typeof(Transform), typeof(Transform), typeof(Vector3)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			obj.LookAt(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Transform arg0 = (Transform)LuaScriptMgr.GetNetObject(L, 2);
			obj.LookAt(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Vector3 arg1 = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
			obj.LookAt(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Transform arg0 = (Transform)LuaScriptMgr.GetNetObject(L, 2);
			Vector3 arg1 = (Vector3)LuaScriptMgr.GetNetObject(L, 3);
			obj.LookAt(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Transform.LookAt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TransformDirection(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Vector3 o = obj.TransformDirection(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			Vector3 o = obj.TransformDirection(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Transform.TransformDirection");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InverseTransformDirection(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Vector3 o = obj.InverseTransformDirection(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			Vector3 o = obj.InverseTransformDirection(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Transform.InverseTransformDirection");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TransformPoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Vector3 o = obj.TransformPoint(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			Vector3 o = obj.TransformPoint(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Transform.TransformPoint");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InverseTransformPoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg0 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Vector3 o = obj.InverseTransformPoint(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			Vector3 o = obj.InverseTransformPoint(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Transform.InverseTransformPoint");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DetachChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		obj.DetachChildren();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAsFirstSibling(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		obj.SetAsFirstSibling();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAsLastSibling(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		obj.SetAsLastSibling();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSiblingIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.SetSiblingIndex(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSiblingIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		int o = obj.GetSiblingIndex();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Find(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Transform o = obj.Find(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsChildOf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		Transform arg0 = (Transform)LuaScriptMgr.GetNetObject(L, 2);
		bool o = obj.IsChildOf(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Transform o = obj.FindChild(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		IEnumerator o = obj.GetEnumerator();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform obj = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Transform o = obj.GetChild(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

