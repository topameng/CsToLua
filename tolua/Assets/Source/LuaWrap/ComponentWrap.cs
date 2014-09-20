using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ComponentWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetComponent", GetComponent),
		new LuaMethod("GetComponentInChildren", GetComponentInChildren),
		new LuaMethod("GetComponentsInChildren", GetComponentsInChildren),
		new LuaMethod("GetComponentInParent", GetComponentInParent),
		new LuaMethod("GetComponentsInParent", GetComponentsInParent),
		new LuaMethod("GetComponents", GetComponents),
		new LuaMethod("CompareTag", CompareTag),
		new LuaMethod("SendMessageUpwards", SendMessageUpwards),
		new LuaMethod("SendMessage", SendMessage),
		new LuaMethod("BroadcastMessage", BroadcastMessage),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("transform", get_transform, null),
		new LuaField("rigidbody", get_rigidbody, null),
		new LuaField("rigidbody2D", get_rigidbody2D, null),
		new LuaField("camera", get_camera, null),
		new LuaField("light", get_light, null),
		new LuaField("animation", get_animation, null),
		new LuaField("constantForce", get_constantForce, null),
		new LuaField("renderer", get_renderer, null),
		new LuaField("audio", get_audio, null),
		new LuaField("guiText", get_guiText, null),
		new LuaField("networkView", get_networkView, null),
		new LuaField("guiTexture", get_guiTexture, null),
		new LuaField("collider", get_collider, null),
		new LuaField("collider2D", get_collider2D, null),
		new LuaField("hingeJoint", get_hingeJoint, null),
		new LuaField("particleEmitter", get_particleEmitter, null),
		new LuaField("particleSystem", get_particleSystem, null),
		new LuaField("gameObject", get_gameObject, null),
		new LuaField("tag", get_tag, set_tag),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object obj = null;

		if (count == 0)
		{
			obj = new Component();
			luaMgr.PushResult(obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Component.New' has some invalid arguments");
		}

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
		reference = luaMgr.RegisterLib("Component", regs);
		luaMgr.CreateMetaTable("Component", metas, typeof(Component));
		luaMgr.RegisterField(typeof(Component), fields);
	}

	static bool get_transform(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.transform);
		return true;
	}

	static bool get_rigidbody(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.rigidbody);
		return true;
	}

	static bool get_rigidbody2D(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.rigidbody2D);
		return true;
	}

	static bool get_camera(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.camera);
		return true;
	}

	static bool get_light(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.light);
		return true;
	}

	static bool get_animation(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.animation);
		return true;
	}

	static bool get_constantForce(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.constantForce);
		return true;
	}

	static bool get_renderer(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.renderer);
		return true;
	}

	static bool get_audio(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.audio);
		return true;
	}

	static bool get_guiText(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.guiText);
		return true;
	}

	static bool get_networkView(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.networkView);
		return true;
	}

	static bool get_guiTexture(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.guiTexture);
		return true;
	}

	static bool get_collider(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.collider);
		return true;
	}

	static bool get_collider2D(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.collider2D);
		return true;
	}

	static bool get_hingeJoint(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.hingeJoint);
		return true;
	}

	static bool get_particleEmitter(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.particleEmitter);
		return true;
	}

	static bool get_particleSystem(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.particleSystem);
		return true;
	}

	static bool get_gameObject(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.gameObject);
		return true;
	}

	static bool get_tag(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		luaMgr.PushResult(obj.tag);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return ObjectWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Component' does not contain a definition for '{0}'", str));
		return 0;
	}

	static bool set_tag(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Component obj = (Component)o;
		obj.tag = luaMgr.GetString(3);
		return true;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return ObjectWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Component' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(Component), typeof(string)};
		Type[] types1 = {typeof(Component), typeof(Type)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Component o = obj.GetComponent(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			Type arg0 = (Type)luaMgr.GetNetObject(2);
			Component o = obj.GetComponent(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Component.GetComponent' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Component obj = (Component)luaMgr.GetNetObject(1);
		Type arg0 = (Type)luaMgr.GetNetObject(2);
		Component o = obj.GetComponentInChildren(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			Type arg0 = (Type)luaMgr.GetNetObject(2);
			Component[] o = obj.GetComponentsInChildren(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			Type arg0 = (Type)luaMgr.GetNetObject(2);
			bool arg1 = luaMgr.GetBoolean(3);
			Component[] o = obj.GetComponentsInChildren(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Component.GetComponentsInChildren' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInParent(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Component obj = (Component)luaMgr.GetNetObject(1);
		Type arg0 = (Type)luaMgr.GetNetObject(2);
		Component o = obj.GetComponentInParent(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInParent(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			Type arg0 = (Type)luaMgr.GetNetObject(2);
			Component[] o = obj.GetComponentsInParent(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			Type arg0 = (Type)luaMgr.GetNetObject(2);
			bool arg1 = luaMgr.GetBoolean(3);
			Component[] o = obj.GetComponentsInParent(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Component.GetComponentsInParent' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponents(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Component obj = (Component)luaMgr.GetNetObject(1);
		Type arg0 = (Type)luaMgr.GetNetObject(2);
		Component[] o = obj.GetComponents(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTag(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Component obj = (Component)luaMgr.GetNetObject(1);
		string arg0 = luaMgr.GetString(2);
		bool o = obj.CompareTag(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessageUpwards(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(Component), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(Component), typeof(string), typeof(object)};

		if (count == 2)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			obj.SendMessageUpwards(arg0);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types1, 1))
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			SendMessageOptions arg1 = (SendMessageOptions)luaMgr.GetNetObject(3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types2, 1))
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			object arg1 = (object)luaMgr.GetNetObject(3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			object arg1 = (object)luaMgr.GetNetObject(3);
			SendMessageOptions arg2 = (SendMessageOptions)luaMgr.GetNetObject(4);
			obj.SendMessageUpwards(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Component.SendMessageUpwards' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(Component), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(Component), typeof(string), typeof(object)};

		if (count == 2)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			obj.SendMessage(arg0);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types1, 1))
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			SendMessageOptions arg1 = (SendMessageOptions)luaMgr.GetNetObject(3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types2, 1))
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			object arg1 = (object)luaMgr.GetNetObject(3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			object arg1 = (object)luaMgr.GetNetObject(3);
			SendMessageOptions arg2 = (SendMessageOptions)luaMgr.GetNetObject(4);
			obj.SendMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Component.SendMessage' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BroadcastMessage(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(Component), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(Component), typeof(string), typeof(object)};

		if (count == 2)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			obj.BroadcastMessage(arg0);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types1, 1))
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			SendMessageOptions arg1 = (SendMessageOptions)luaMgr.GetNetObject(3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && luaMgr.CheckTypes(types2, 1))
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			object arg1 = (object)luaMgr.GetNetObject(3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Component obj = (Component)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			object arg1 = (object)luaMgr.GetNetObject(3);
			SendMessageOptions arg2 = (SendMessageOptions)luaMgr.GetNetObject(4);
			obj.BroadcastMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Component.BroadcastMessage' has some invalid arguments");
		}

		return 0;
	}
}

