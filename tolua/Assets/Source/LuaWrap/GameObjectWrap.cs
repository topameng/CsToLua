using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class GameObjectWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SampleAnimation", SampleAnimation),
		new LuaMethod("CreatePrimitive", CreatePrimitive),
		new LuaMethod("GetComponent", GetComponent),
		new LuaMethod("GetComponentInChildren", GetComponentInChildren),
		new LuaMethod("GetComponentInParent", GetComponentInParent),
		new LuaMethod("GetComponents", GetComponents),
		new LuaMethod("GetComponentsInChildren", GetComponentsInChildren),
		new LuaMethod("GetComponentsInParent", GetComponentsInParent),
		new LuaMethod("SetActive", SetActive),
		new LuaMethod("CompareTag", CompareTag),
		new LuaMethod("FindGameObjectWithTag", FindGameObjectWithTag),
		new LuaMethod("FindWithTag", FindWithTag),
		new LuaMethod("FindGameObjectsWithTag", FindGameObjectsWithTag),
		new LuaMethod("SendMessageUpwards", SendMessageUpwards),
		new LuaMethod("SendMessage", SendMessage),
		new LuaMethod("BroadcastMessage", BroadcastMessage),
		new LuaMethod("AddComponent", AddComponent),
		new LuaMethod("Find", Find),
		new LuaMethod("New", _CreateGameObject),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("isStatic", get_isStatic, set_isStatic),
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
		new LuaField("layer", get_layer, set_layer),
		new LuaField("activeSelf", get_activeSelf, null),
		new LuaField("activeInHierarchy", get_activeInHierarchy, null),
		new LuaField("tag", get_tag, set_tag),
		new LuaField("gameObject", get_gameObject, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGameObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GameObject obj = new GameObject();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GameObject obj = new GameObject(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(Type), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Type[] objs1 = LuaScriptMgr.GetParamsObject<Type>(L, 2, count - 1);
			GameObject obj = new GameObject(arg0,objs1);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.New");
		}

		return 0;
	}

	static Type classType = typeof(GameObject);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);

		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.GameObject", typeof(GameObject), regs, fields, typeof(Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isStatic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isStatic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isStatic on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isStatic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name transform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index transform on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.transform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rigidbody(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rigidbody");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rigidbody on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rigidbody);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rigidbody2D(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rigidbody2D");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rigidbody2D on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rigidbody2D);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_camera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name camera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index camera on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.camera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_light(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name light");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index light on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.light);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animation on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.animation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_constantForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name constantForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index constantForce on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.constantForce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderer on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.renderer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_audio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name audio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index audio on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.audio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_guiText(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name guiText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index guiText on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.guiText);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_networkView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name networkView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index networkView on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.networkView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_guiTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name guiTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index guiTexture on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.guiTexture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collider(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name collider");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index collider on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.collider);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collider2D(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name collider2D");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index collider2D on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.collider2D);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hingeJoint(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hingeJoint");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hingeJoint on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.hingeJoint);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_particleEmitter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name particleEmitter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index particleEmitter on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.particleEmitter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_particleSystem(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name particleSystem");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index particleSystem on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.particleSystem);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layer on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.layer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeSelf(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeSelf");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeSelf on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.activeSelf);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeInHierarchy(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeInHierarchy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeInHierarchy on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.activeInHierarchy);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tag on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gameObject");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gameObject on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.gameObject);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isStatic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isStatic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isStatic on a nil value");
			}
		}

		obj.isStatic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layer on a nil value");
			}
		}

		obj.layer = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		GameObject obj = (GameObject)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tag on a nil value");
			}
		}

		obj.tag = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SampleAnimation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		AnimationClip arg0 = (AnimationClip)LuaScriptMgr.GetUnityObject(L, 2, typeof(AnimationClip));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.SampleAnimation(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreatePrimitive(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		PrimitiveType arg0 = (PrimitiveType)LuaScriptMgr.GetNetObject(L, 1, typeof(PrimitiveType));
		GameObject o = GameObject.CreatePrimitive(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Component o = obj.GetComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(Type)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component o = obj.GetComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		Component o = obj.GetComponentInChildren(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInParent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		Component o = obj.GetComponentInParent(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 2)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponents(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			List<Component> arg1 = (List<Component>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<Component>));
			obj.GetComponents(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 2)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponentsInChildren(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Component[] o = obj.GetComponentsInChildren(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponentsInChildren");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInParent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 2)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponentsInParent(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Component[] o = obj.GetComponentsInParent(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponentsInParent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetActive(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.SetActive(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.CompareTag(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindGameObjectWithTag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject o = GameObject.FindGameObjectWithTag(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindWithTag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject o = GameObject.FindWithTag(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindGameObjectsWithTag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject[] o = GameObject.FindGameObjectsWithTag(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessageUpwards(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendMessageUpwards(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(SendMessageOptions)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = (SendMessageOptions)LuaScriptMgr.GetNetObject(L, 3, typeof(SendMessageOptions));
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = (SendMessageOptions)LuaScriptMgr.GetNetObject(L, 4, typeof(SendMessageOptions));
			obj.SendMessageUpwards(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.SendMessageUpwards");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendMessage(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(SendMessageOptions)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = (SendMessageOptions)LuaScriptMgr.GetNetObject(L, 3, typeof(SendMessageOptions));
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = (SendMessageOptions)LuaScriptMgr.GetNetObject(L, 4, typeof(SendMessageOptions));
			obj.SendMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.SendMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BroadcastMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.BroadcastMessage(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(SendMessageOptions)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = (SendMessageOptions)LuaScriptMgr.GetNetObject(L, 3, typeof(SendMessageOptions));
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = (SendMessageOptions)LuaScriptMgr.GetNetObject(L, 4, typeof(SendMessageOptions));
			obj.BroadcastMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.BroadcastMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddComponent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(Type)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component o = obj.AddComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
		{
			GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Component o = obj.AddComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.AddComponent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Find(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject o = GameObject.Find(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

