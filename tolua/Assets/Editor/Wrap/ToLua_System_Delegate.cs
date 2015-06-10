using System;
using System.Collections;

public class ToLua_System_Delegate
{    
    [NoToLuaAttribute]
    public static string op_AdditionDefined =
@"        LuaScriptMgr.CheckArgsCount(L, 2);
        Delegate arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Delegate;
        
        LuaTypes type = LuaDLL.lua_type(L, 2);

        if (type != LuaTypes.LUA_TFUNCTION)
        {
            Delegate arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Delegate;            
            Delegate o = Delegate.Combine(arg0, arg1);                        
            LuaScriptMgr.Push(L, o);
            return 1;            
        }
        else
        {
            LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
            Delegate arg1 = DelegateFactory.CreateDelegate(arg0.GetType(), func);
            Delegate o = Delegate.Combine(arg0, arg1);
            LuaScriptMgr.Push(L, o);            
            return 1;
        }                        
    ";

    [NoToLuaAttribute]
    public static string op_SubtractionDefined =
    @"        LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate arg0 = (Delegate)LuaScriptMgr.GetNetObject(L, 1, typeof(Delegate));
		Delegate arg1 = (Delegate)LuaScriptMgr.GetNetObject(L, 2, typeof(Delegate));
        Delegate o = Delegate.Remove(arg0, arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
    ";

    public static bool operator ==(ToLua_System_Delegate lhs, ToLua_System_Delegate rhs)
    {
        return false;
    }

    public static bool operator !=(ToLua_System_Delegate lhs, ToLua_System_Delegate rhs)
    {
        return false;
    }

    [UseDefinedAttribute]
    public static ToLua_System_Delegate operator +(ToLua_System_Delegate a, ToLua_System_Delegate b)
    {
        return null;
    }

    [UseDefinedAttribute]
    public static ToLua_System_Delegate operator -(ToLua_System_Delegate a, ToLua_System_Delegate b)
    {
        return null;
    }


    public override bool Equals(object other)
    {
        return false;
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
