using UnityEngine;
using System;
using LuaInterface;

public class InputWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetAxis", GetAxis),
		new LuaMethod("GetAxisRaw", GetAxisRaw),
		new LuaMethod("GetButton", GetButton),
		new LuaMethod("GetButtonDown", GetButtonDown),
		new LuaMethod("GetButtonUp", GetButtonUp),
		new LuaMethod("GetKey", GetKey),
		new LuaMethod("GetKeyDown", GetKeyDown),
		new LuaMethod("GetKeyUp", GetKeyUp),
		new LuaMethod("GetJoystickNames", GetJoystickNames),
		new LuaMethod("GetMouseButton", GetMouseButton),
		new LuaMethod("GetMouseButtonDown", GetMouseButtonDown),
		new LuaMethod("GetMouseButtonUp", GetMouseButtonUp),
		new LuaMethod("ResetInputAxes", ResetInputAxes),
		new LuaMethod("GetAccelerationEvent", GetAccelerationEvent),
		new LuaMethod("GetTouch", GetTouch),
		new LuaMethod("New", _CreateInput),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("compensateSensors", get_compensateSensors, set_compensateSensors),
		new LuaField("gyro", get_gyro, null),
		new LuaField("mousePosition", get_mousePosition, null),
		new LuaField("mousePresent", get_mousePresent, null),
		new LuaField("simulateMouseWithTouches", get_simulateMouseWithTouches, set_simulateMouseWithTouches),
		new LuaField("anyKey", get_anyKey, null),
		new LuaField("anyKeyDown", get_anyKeyDown, null),
		new LuaField("inputString", get_inputString, null),
		new LuaField("acceleration", get_acceleration, null),
		new LuaField("accelerationEvents", get_accelerationEvents, null),
		new LuaField("accelerationEventCount", get_accelerationEventCount, null),
		new LuaField("touches", get_touches, null),
		new LuaField("touchCount", get_touchCount, null),
		new LuaField("multiTouchEnabled", get_multiTouchEnabled, set_multiTouchEnabled),
		new LuaField("location", get_location, null),
		new LuaField("compass", get_compass, null),
		new LuaField("deviceOrientation", get_deviceOrientation, null),
		new LuaField("imeCompositionMode", get_imeCompositionMode, set_imeCompositionMode),
		new LuaField("compositionString", get_compositionString, null),
		new LuaField("imeIsSelected", get_imeIsSelected, null),
		new LuaField("compositionCursorPos", get_compositionCursorPos, set_compositionCursorPos),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateInput(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Input obj = new Input();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Input.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Input));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Input", typeof(Input), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_compensateSensors(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.compensateSensors);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gyro(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Input.gyro);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mousePosition(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Input.mousePosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mousePresent(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.mousePresent);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_simulateMouseWithTouches(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.simulateMouseWithTouches);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anyKey(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.anyKey);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anyKeyDown(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.anyKeyDown);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inputString(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.inputString);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_acceleration(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Input.acceleration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_accelerationEvents(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Input.accelerationEvents);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_accelerationEventCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.accelerationEventCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_touches(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Input.touches);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_touchCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.touchCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_multiTouchEnabled(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.multiTouchEnabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_location(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Input.location);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_compass(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Input.compass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceOrientation(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, Input.deviceOrientation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_imeCompositionMode(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, Input.imeCompositionMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_compositionString(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.compositionString);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_imeIsSelected(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.imeIsSelected);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_compositionCursorPos(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Input.compositionCursorPos);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_compensateSensors(IntPtr L)
	{
		Input.compensateSensors = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_simulateMouseWithTouches(IntPtr L)
	{
		Input.simulateMouseWithTouches = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_multiTouchEnabled(IntPtr L)
	{
		Input.multiTouchEnabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_imeCompositionMode(IntPtr L)
	{
		Input.imeCompositionMode = LuaScriptMgr.GetNetObject<IMECompositionMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_compositionCursorPos(IntPtr L)
	{
		Input.compositionCursorPos = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAxis(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		float o = Input.GetAxis(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAxisRaw(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		float o = Input.GetAxisRaw(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetButton(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Input.GetButton(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetButtonDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Input.GetButtonDown(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetButtonUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Input.GetButtonUp(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKey(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(KeyCode)};
		Type[] types1 = {typeof(string)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			KeyCode arg0 = LuaScriptMgr.GetNetObject<KeyCode>(L, 1);
			bool o = Input.GetKey(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			bool o = Input.GetKey(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Input.GetKey");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeyDown(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(KeyCode)};
		Type[] types1 = {typeof(string)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			KeyCode arg0 = LuaScriptMgr.GetNetObject<KeyCode>(L, 1);
			bool o = Input.GetKeyDown(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			bool o = Input.GetKeyDown(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Input.GetKeyDown");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeyUp(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(KeyCode)};
		Type[] types1 = {typeof(string)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			KeyCode arg0 = LuaScriptMgr.GetNetObject<KeyCode>(L, 1);
			bool o = Input.GetKeyUp(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			bool o = Input.GetKeyUp(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Input.GetKeyUp");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickNames(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string[] o = Input.GetJoystickNames();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouseButton(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		bool o = Input.GetMouseButton(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouseButtonDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		bool o = Input.GetMouseButtonDown(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouseButtonUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		bool o = Input.GetMouseButtonUp(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetInputAxes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Input.ResetInputAxes();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAccelerationEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		AccelerationEvent o = Input.GetAccelerationEvent(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTouch(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		Touch o = Input.GetTouch(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}
}

