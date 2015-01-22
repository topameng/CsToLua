using UnityEngine;
using System;
using LuaInterface;

public class CoroutineWrap 
{
    public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("waitforseconds", WaitForSeconds),
        new LuaMethod("yieldone", Yield),
        new LuaMethod("waitforendofframe", WaitForEndOfFrame),
	};

    public static void Register(IntPtr L)
    {
        LuaScriptMgr.RegisterLib(L, "coroutine", regs);
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WaitForSeconds(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);        
        float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);

        Action action = () =>
        {
            int ret = LuaDLL.lua_resume(L, 0);

            if (ret > (int)LuaThreadStatus.LUA_YIELD)
            {
                ThrowExceptionFromError(L);
            }
        };

        Timer.Instance.AddTimer(arg0, 1, action);
        return LuaDLL.lua_yield(L, 0);
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Yield(IntPtr L)
    {
        Action action = () =>
        {
            int ret = LuaDLL.lua_resume(L, 0);

            if (ret > (int)LuaThreadStatus.LUA_YIELD)
            {
                ThrowExceptionFromError(L);
            }
        };

        Timer.Instance.Yield(1, action);
        return LuaDLL.lua_yield(L, 0);
    }    
    
    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int WaitForEndOfFrame(IntPtr L)
    {
        Action action = () =>
        {
            int ret = LuaDLL.lua_resume(L, 0);

            if (ret > (int)LuaThreadStatus.LUA_YIELD)
            {
                ThrowExceptionFromError(L);
            }
        };

        Timer.Instance.WaitEndOfFrame(action);
        return LuaDLL.lua_yield(L, 0);
    } 

    static void ThrowExceptionFromError(IntPtr L)
    {
        int oldTop = LuaDLL.lua_gettop(L);
        object err = ObjectTranslator.FromState(L).getObject(L, -1);
        LuaDLL.lua_settop(L, oldTop);
        if (err == null) err = "Unknown Lua Error";
        throw new LuaScriptException(err.ToString(), "");
    }
}
