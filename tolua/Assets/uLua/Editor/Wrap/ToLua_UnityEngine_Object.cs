using UnityEngine;
using System.Collections;

public class ToLua_UnityEngine_Object     
{
    [NoToLuaAttribute]
    public static string DestroyDefined =
@"		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
            LuaScriptMgr.__gc(L);
			Object.Destroy(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
            LuaScriptMgr.__gc(L);
			Object.Destroy(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, ""invalid arguments to method: Object.Destroy"");
		}

		return 0;
";
    [NoToLuaAttribute]
    public static string DestroyImmediateDefined =
@"		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
            LuaScriptMgr.__gc(L);
			Object.DestroyImmediate(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
            LuaScriptMgr.__gc(L);
			Object.DestroyImmediate(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, ""invalid arguments to method: Object.DestroyImmediate"");
		}

		return 0;
";

    [NoToLuaAttribute]
    public static string DestroyObjectDefined =
@"		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
            LuaScriptMgr.__gc(L);
			Object.DestroyObject(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
            LuaScriptMgr.__gc(L);
			Object.DestroyObject(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, ""invalid arguments to method: Object.DestroyObject"");
		}

		return 0;
";

    [UseDefinedAttribute]
    public static void Destroy(Object obj)
    {
        
    }

    [UseDefinedAttribute]
    public static void DestroyImmediate(Object obj)
    {

    }

    [UseDefinedAttribute]
    public static void DestroyObject(Object obj)
    {

    }   
}
