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
    public LuaCSFunction getter;
    public LuaCSFunction setter;

    public LuaField(string str, LuaCSFunction g, LuaCSFunction s)
    {
        name = str;
        getter = g;
        setter = s;
    }
};

public struct LuaEnum
{
    public string name;
    public object val;

    public LuaEnum(string str, object v)
    {
        name = str;
        val = v;
    }
}

//public interface ILuaWrap 
//{
//    void Register();
//}

public class NoToLuaAttribute : System.Attribute
{
    public NoToLuaAttribute()
    {

    }
}
