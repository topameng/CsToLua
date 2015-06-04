using UnityEngine;
using System.Collections;

public class ToLua_System_String
{
    [NoToLuaAttribute]
    public static string ToLua_System_StringDefined =
@"        LuaTypes luatype = LuaDLL.lua_type(L, 1);

        if (luatype == LuaTypes.LUA_TSTRING)
        {
            string arg0 = LuaDLL.lua_tostring(L, 1);
            LuaScriptMgr.PushObject(L, arg0);
            return 1;
        }
        else
        {
            LuaDLL.luaL_error(L, ""invalid arguments to method: String.New"");
        }
        
		return 0;";

    public static string EqualsDefined =
@"		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(string)))
		{
			string obj = LuaScriptMgr.GetVarObject(L, 1) as string;
			string arg0 = LuaScriptMgr.GetString(L, 2);
			bool o = obj != null ? obj.Equals(arg0) : arg0 == null;
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof(object)))
		{
			string obj = LuaScriptMgr.GetVarObject(L, 1) as string;
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			bool o = obj != null ? obj.Equals(arg0) : arg0 == null;
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string obj = LuaScriptMgr.GetVarObject(L, 1) as string;
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			StringComparison arg1 = (StringComparison)LuaScriptMgr.GetNetObject(L, 3, typeof(StringComparison));
			bool o = obj != null ? obj.Equals(arg0, arg1) : arg0 == null;
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, ""invalid arguments to method: string.Equals"");
		}

		return 0;";

    [UseDefinedAttribute]
    public ToLua_System_String()
    {

    }

    [UseDefinedAttribute]
    public bool Equals(string value)
    {
        return false;
    }
}
