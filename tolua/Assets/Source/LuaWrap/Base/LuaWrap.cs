using System;
using LuaInterface;
using System.Runtime.InteropServices;


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

public class NoToLuaAttribute : System.Attribute
{
    public NoToLuaAttribute()
    {

    }
}

public interface ILuaWrap 
{
    void Register();
}

public class LuaStringBuffer
{
    public LuaStringBuffer(IntPtr source,int len)
    {
        buffer = new byte[len];
        Marshal.Copy(source, buffer, 0, len);        
    }

    public byte[] buffer = null;    
}