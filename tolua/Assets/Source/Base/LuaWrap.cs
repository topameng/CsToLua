using System;
using LuaInterface;


public struct LuaMethod
{
    public string name;
    public LuaCSFunction func;

    public LuaMethod(string str, LuaCSFunction f)
    {
        name = str;
        func = f;
    }
};

public struct LuaField
{
    public string name;
    public Func<IntPtr, bool> getter;
    public Func<IntPtr, bool> setter;

    public LuaField(string str, Func<IntPtr, bool> g, Func<IntPtr, bool> s)
    {
        name = str;
        getter = g;
        setter = s;        
    }
};

public interface ILuaWrap 
{
    void Register();
}