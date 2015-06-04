using System;
using UnityEngine;
using LuaInterface;

public class KeyCodeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("None", GetNone),
		new LuaMethod("Backspace", GetBackspace),
		new LuaMethod("Delete", GetDelete),
		new LuaMethod("Tab", GetTab),
		new LuaMethod("Clear", GetClear),
		new LuaMethod("Return", GetReturn),
		new LuaMethod("Pause", GetPause),
		new LuaMethod("Escape", GetEscape),
		new LuaMethod("Space", GetSpace),
		new LuaMethod("Keypad0", GetKeypad0),
		new LuaMethod("Keypad1", GetKeypad1),
		new LuaMethod("Keypad2", GetKeypad2),
		new LuaMethod("Keypad3", GetKeypad3),
		new LuaMethod("Keypad4", GetKeypad4),
		new LuaMethod("Keypad5", GetKeypad5),
		new LuaMethod("Keypad6", GetKeypad6),
		new LuaMethod("Keypad7", GetKeypad7),
		new LuaMethod("Keypad8", GetKeypad8),
		new LuaMethod("Keypad9", GetKeypad9),
		new LuaMethod("KeypadPeriod", GetKeypadPeriod),
		new LuaMethod("KeypadDivide", GetKeypadDivide),
		new LuaMethod("KeypadMultiply", GetKeypadMultiply),
		new LuaMethod("KeypadMinus", GetKeypadMinus),
		new LuaMethod("KeypadPlus", GetKeypadPlus),
		new LuaMethod("KeypadEnter", GetKeypadEnter),
		new LuaMethod("KeypadEquals", GetKeypadEquals),
		new LuaMethod("UpArrow", GetUpArrow),
		new LuaMethod("DownArrow", GetDownArrow),
		new LuaMethod("RightArrow", GetRightArrow),
		new LuaMethod("LeftArrow", GetLeftArrow),
		new LuaMethod("Insert", GetInsert),
		new LuaMethod("Home", GetHome),
		new LuaMethod("End", GetEnd),
		new LuaMethod("PageUp", GetPageUp),
		new LuaMethod("PageDown", GetPageDown),
		new LuaMethod("F1", GetF1),
		new LuaMethod("F2", GetF2),
		new LuaMethod("F3", GetF3),
		new LuaMethod("F4", GetF4),
		new LuaMethod("F5", GetF5),
		new LuaMethod("F6", GetF6),
		new LuaMethod("F7", GetF7),
		new LuaMethod("F8", GetF8),
		new LuaMethod("F9", GetF9),
		new LuaMethod("F10", GetF10),
		new LuaMethod("F11", GetF11),
		new LuaMethod("F12", GetF12),
		new LuaMethod("F13", GetF13),
		new LuaMethod("F14", GetF14),
		new LuaMethod("F15", GetF15),
		new LuaMethod("Alpha0", GetAlpha0),
		new LuaMethod("Alpha1", GetAlpha1),
		new LuaMethod("Alpha2", GetAlpha2),
		new LuaMethod("Alpha3", GetAlpha3),
		new LuaMethod("Alpha4", GetAlpha4),
		new LuaMethod("Alpha5", GetAlpha5),
		new LuaMethod("Alpha6", GetAlpha6),
		new LuaMethod("Alpha7", GetAlpha7),
		new LuaMethod("Alpha8", GetAlpha8),
		new LuaMethod("Alpha9", GetAlpha9),
		new LuaMethod("Exclaim", GetExclaim),
		new LuaMethod("DoubleQuote", GetDoubleQuote),
		new LuaMethod("Hash", GetHash),
		new LuaMethod("Dollar", GetDollar),
		new LuaMethod("Ampersand", GetAmpersand),
		new LuaMethod("Quote", GetQuote),
		new LuaMethod("LeftParen", GetLeftParen),
		new LuaMethod("RightParen", GetRightParen),
		new LuaMethod("Asterisk", GetAsterisk),
		new LuaMethod("Plus", GetPlus),
		new LuaMethod("Comma", GetComma),
		new LuaMethod("Minus", GetMinus),
		new LuaMethod("Period", GetPeriod),
		new LuaMethod("Slash", GetSlash),
		new LuaMethod("Colon", GetColon),
		new LuaMethod("Semicolon", GetSemicolon),
		new LuaMethod("Less", GetLess),
		new LuaMethod("Equals", GetEquals),
		new LuaMethod("Greater", GetGreater),
		new LuaMethod("Question", GetQuestion),
		new LuaMethod("At", GetAt),
		new LuaMethod("LeftBracket", GetLeftBracket),
		new LuaMethod("Backslash", GetBackslash),
		new LuaMethod("RightBracket", GetRightBracket),
		new LuaMethod("Caret", GetCaret),
		new LuaMethod("Underscore", GetUnderscore),
		new LuaMethod("BackQuote", GetBackQuote),
		new LuaMethod("A", GetA),
		new LuaMethod("B", GetB),
		new LuaMethod("C", GetC),
		new LuaMethod("D", GetD),
		new LuaMethod("E", GetE),
		new LuaMethod("F", GetF),
		new LuaMethod("G", GetG),
		new LuaMethod("H", GetH),
		new LuaMethod("I", GetI),
		new LuaMethod("J", GetJ),
		new LuaMethod("K", GetK),
		new LuaMethod("L", GetL),
		new LuaMethod("M", GetM),
		new LuaMethod("N", GetN),
		new LuaMethod("O", GetO),
		new LuaMethod("P", GetP),
		new LuaMethod("Q", GetQ),
		new LuaMethod("R", GetR),
		new LuaMethod("S", GetS),
		new LuaMethod("T", GetT),
		new LuaMethod("U", GetU),
		new LuaMethod("V", GetV),
		new LuaMethod("W", GetW),
		new LuaMethod("X", GetX),
		new LuaMethod("Y", GetY),
		new LuaMethod("Z", GetZ),
		new LuaMethod("Numlock", GetNumlock),
		new LuaMethod("CapsLock", GetCapsLock),
		new LuaMethod("ScrollLock", GetScrollLock),
		new LuaMethod("RightShift", GetRightShift),
		new LuaMethod("LeftShift", GetLeftShift),
		new LuaMethod("RightControl", GetRightControl),
		new LuaMethod("LeftControl", GetLeftControl),
		new LuaMethod("RightAlt", GetRightAlt),
		new LuaMethod("LeftAlt", GetLeftAlt),
		new LuaMethod("LeftCommand", GetLeftCommand),
		new LuaMethod("LeftApple", GetLeftApple),
		new LuaMethod("LeftWindows", GetLeftWindows),
		new LuaMethod("RightCommand", GetRightCommand),
		new LuaMethod("RightApple", GetRightApple),
		new LuaMethod("RightWindows", GetRightWindows),
		new LuaMethod("AltGr", GetAltGr),
		new LuaMethod("Help", GetHelp),
		new LuaMethod("Print", GetPrint),
		new LuaMethod("SysReq", GetSysReq),
		new LuaMethod("Break", GetBreak),
		new LuaMethod("Menu", GetMenu),
		new LuaMethod("Mouse0", GetMouse0),
		new LuaMethod("Mouse1", GetMouse1),
		new LuaMethod("Mouse2", GetMouse2),
		new LuaMethod("Mouse3", GetMouse3),
		new LuaMethod("Mouse4", GetMouse4),
		new LuaMethod("Mouse5", GetMouse5),
		new LuaMethod("Mouse6", GetMouse6),
		new LuaMethod("JoystickButton0", GetJoystickButton0),
		new LuaMethod("JoystickButton1", GetJoystickButton1),
		new LuaMethod("JoystickButton2", GetJoystickButton2),
		new LuaMethod("JoystickButton3", GetJoystickButton3),
		new LuaMethod("JoystickButton4", GetJoystickButton4),
		new LuaMethod("JoystickButton5", GetJoystickButton5),
		new LuaMethod("JoystickButton6", GetJoystickButton6),
		new LuaMethod("JoystickButton7", GetJoystickButton7),
		new LuaMethod("JoystickButton8", GetJoystickButton8),
		new LuaMethod("JoystickButton9", GetJoystickButton9),
		new LuaMethod("JoystickButton10", GetJoystickButton10),
		new LuaMethod("JoystickButton11", GetJoystickButton11),
		new LuaMethod("JoystickButton12", GetJoystickButton12),
		new LuaMethod("JoystickButton13", GetJoystickButton13),
		new LuaMethod("JoystickButton14", GetJoystickButton14),
		new LuaMethod("JoystickButton15", GetJoystickButton15),
		new LuaMethod("JoystickButton16", GetJoystickButton16),
		new LuaMethod("JoystickButton17", GetJoystickButton17),
		new LuaMethod("JoystickButton18", GetJoystickButton18),
		new LuaMethod("JoystickButton19", GetJoystickButton19),
		new LuaMethod("Joystick1Button0", GetJoystick1Button0),
		new LuaMethod("Joystick1Button1", GetJoystick1Button1),
		new LuaMethod("Joystick1Button2", GetJoystick1Button2),
		new LuaMethod("Joystick1Button3", GetJoystick1Button3),
		new LuaMethod("Joystick1Button4", GetJoystick1Button4),
		new LuaMethod("Joystick1Button5", GetJoystick1Button5),
		new LuaMethod("Joystick1Button6", GetJoystick1Button6),
		new LuaMethod("Joystick1Button7", GetJoystick1Button7),
		new LuaMethod("Joystick1Button8", GetJoystick1Button8),
		new LuaMethod("Joystick1Button9", GetJoystick1Button9),
		new LuaMethod("Joystick1Button10", GetJoystick1Button10),
		new LuaMethod("Joystick1Button11", GetJoystick1Button11),
		new LuaMethod("Joystick1Button12", GetJoystick1Button12),
		new LuaMethod("Joystick1Button13", GetJoystick1Button13),
		new LuaMethod("Joystick1Button14", GetJoystick1Button14),
		new LuaMethod("Joystick1Button15", GetJoystick1Button15),
		new LuaMethod("Joystick1Button16", GetJoystick1Button16),
		new LuaMethod("Joystick1Button17", GetJoystick1Button17),
		new LuaMethod("Joystick1Button18", GetJoystick1Button18),
		new LuaMethod("Joystick1Button19", GetJoystick1Button19),
		new LuaMethod("Joystick2Button0", GetJoystick2Button0),
		new LuaMethod("Joystick2Button1", GetJoystick2Button1),
		new LuaMethod("Joystick2Button2", GetJoystick2Button2),
		new LuaMethod("Joystick2Button3", GetJoystick2Button3),
		new LuaMethod("Joystick2Button4", GetJoystick2Button4),
		new LuaMethod("Joystick2Button5", GetJoystick2Button5),
		new LuaMethod("Joystick2Button6", GetJoystick2Button6),
		new LuaMethod("Joystick2Button7", GetJoystick2Button7),
		new LuaMethod("Joystick2Button8", GetJoystick2Button8),
		new LuaMethod("Joystick2Button9", GetJoystick2Button9),
		new LuaMethod("Joystick2Button10", GetJoystick2Button10),
		new LuaMethod("Joystick2Button11", GetJoystick2Button11),
		new LuaMethod("Joystick2Button12", GetJoystick2Button12),
		new LuaMethod("Joystick2Button13", GetJoystick2Button13),
		new LuaMethod("Joystick2Button14", GetJoystick2Button14),
		new LuaMethod("Joystick2Button15", GetJoystick2Button15),
		new LuaMethod("Joystick2Button16", GetJoystick2Button16),
		new LuaMethod("Joystick2Button17", GetJoystick2Button17),
		new LuaMethod("Joystick2Button18", GetJoystick2Button18),
		new LuaMethod("Joystick2Button19", GetJoystick2Button19),
		new LuaMethod("Joystick3Button0", GetJoystick3Button0),
		new LuaMethod("Joystick3Button1", GetJoystick3Button1),
		new LuaMethod("Joystick3Button2", GetJoystick3Button2),
		new LuaMethod("Joystick3Button3", GetJoystick3Button3),
		new LuaMethod("Joystick3Button4", GetJoystick3Button4),
		new LuaMethod("Joystick3Button5", GetJoystick3Button5),
		new LuaMethod("Joystick3Button6", GetJoystick3Button6),
		new LuaMethod("Joystick3Button7", GetJoystick3Button7),
		new LuaMethod("Joystick3Button8", GetJoystick3Button8),
		new LuaMethod("Joystick3Button9", GetJoystick3Button9),
		new LuaMethod("Joystick3Button10", GetJoystick3Button10),
		new LuaMethod("Joystick3Button11", GetJoystick3Button11),
		new LuaMethod("Joystick3Button12", GetJoystick3Button12),
		new LuaMethod("Joystick3Button13", GetJoystick3Button13),
		new LuaMethod("Joystick3Button14", GetJoystick3Button14),
		new LuaMethod("Joystick3Button15", GetJoystick3Button15),
		new LuaMethod("Joystick3Button16", GetJoystick3Button16),
		new LuaMethod("Joystick3Button17", GetJoystick3Button17),
		new LuaMethod("Joystick3Button18", GetJoystick3Button18),
		new LuaMethod("Joystick3Button19", GetJoystick3Button19),
		new LuaMethod("Joystick4Button0", GetJoystick4Button0),
		new LuaMethod("Joystick4Button1", GetJoystick4Button1),
		new LuaMethod("Joystick4Button2", GetJoystick4Button2),
		new LuaMethod("Joystick4Button3", GetJoystick4Button3),
		new LuaMethod("Joystick4Button4", GetJoystick4Button4),
		new LuaMethod("Joystick4Button5", GetJoystick4Button5),
		new LuaMethod("Joystick4Button6", GetJoystick4Button6),
		new LuaMethod("Joystick4Button7", GetJoystick4Button7),
		new LuaMethod("Joystick4Button8", GetJoystick4Button8),
		new LuaMethod("Joystick4Button9", GetJoystick4Button9),
		new LuaMethod("Joystick4Button10", GetJoystick4Button10),
		new LuaMethod("Joystick4Button11", GetJoystick4Button11),
		new LuaMethod("Joystick4Button12", GetJoystick4Button12),
		new LuaMethod("Joystick4Button13", GetJoystick4Button13),
		new LuaMethod("Joystick4Button14", GetJoystick4Button14),
		new LuaMethod("Joystick4Button15", GetJoystick4Button15),
		new LuaMethod("Joystick4Button16", GetJoystick4Button16),
		new LuaMethod("Joystick4Button17", GetJoystick4Button17),
		new LuaMethod("Joystick4Button18", GetJoystick4Button18),
		new LuaMethod("Joystick4Button19", GetJoystick4Button19),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.KeyCode", typeof(UnityEngine.KeyCode), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNone(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.None);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBackspace(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Backspace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDelete(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Delete);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTab(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Tab);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClear(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Clear);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReturn(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Return);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPause(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Pause);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEscape(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Escape);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSpace(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Space);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad7);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad8);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypad9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad9);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypadPeriod(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadPeriod);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypadDivide(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadDivide);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypadMultiply(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadMultiply);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypadMinus(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadMinus);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypadPlus(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadPlus);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypadEnter(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadEnter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKeypadEquals(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadEquals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUpArrow(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.UpArrow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDownArrow(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.DownArrow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightArrow(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightArrow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftArrow(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftArrow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInsert(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Insert);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHome(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Home);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnd(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.End);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPageUp(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.PageUp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPageDown(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.PageDown);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F7);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F8);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F9);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F10);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F11);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F12);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F13);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F14);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F15);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha7);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha8);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAlpha9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha9);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetExclaim(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Exclaim);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDoubleQuote(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.DoubleQuote);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHash(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Hash);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDollar(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Dollar);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAmpersand(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Ampersand);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetQuote(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Quote);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftParen(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftParen);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightParen(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightParen);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAsterisk(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Asterisk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPlus(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Plus);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComma(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Comma);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMinus(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Minus);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPeriod(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Period);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSlash(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Slash);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetColon(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Colon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSemicolon(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Semicolon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLess(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Less);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEquals(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Equals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGreater(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Greater);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetQuestion(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Question);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAt(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.At);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftBracket(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftBracket);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBackslash(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Backslash);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightBracket(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightBracket);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCaret(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Caret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUnderscore(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Underscore);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBackQuote(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.BackQuote);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetA(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.A);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetB(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.B);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetC(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.C);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetD(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.D);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetE(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.E);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetG(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.G);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetH(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.H);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetI(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.I);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJ(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.J);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetK(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.K);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetL(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.L);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetM(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.M);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetN(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.N);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetO(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.O);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetP(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.P);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Q);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetR(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.R);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetS(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.S);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetT(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.T);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetU(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.U);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetV(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.V);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetW(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.W);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetX(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.X);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetY(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Y);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetZ(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Z);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNumlock(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Numlock);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCapsLock(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.CapsLock);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetScrollLock(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.ScrollLock);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightShift(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightShift);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftShift(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftShift);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightControl(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightControl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftControl(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftControl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightAlt(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightAlt);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftAlt(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftAlt);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftCommand(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftCommand);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftApple(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftApple);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLeftWindows(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftWindows);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightCommand(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightCommand);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightApple(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightApple);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRightWindows(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightWindows);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAltGr(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.AltGr);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHelp(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Help);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPrint(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Print);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSysReq(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.SysReq);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBreak(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Break);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMenu(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Menu);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouse0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouse1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouse2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouse3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouse4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouse5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMouse6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton7);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton8);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton9);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton10);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton11);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton12);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton13);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton14);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton15);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton16);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton17);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton18);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystickButton19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton19);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button7);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button8);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button9);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button10);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button11);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button12);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button13);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button14);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button15);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button16);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button17);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button18);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick1Button19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button19);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button7);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button8);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button9);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button10);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button11);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button12);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button13);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button14);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button15);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button16);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button17);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button18);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick2Button19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button19);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button7);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button8);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button9);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button10);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button11);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button12);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button13);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button14);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button15);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button16);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button17);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button18);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick3Button19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button19);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button0);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button5);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button6);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button7);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button8);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button9);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button10);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button11);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button12);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button13);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button14);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button15);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button16);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button17);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button18);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJoystick4Button19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button19);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		KeyCode o = (KeyCode)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

