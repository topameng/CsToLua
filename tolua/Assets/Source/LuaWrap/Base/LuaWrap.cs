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

/*public struct LuaEnum
{
    public string name;
    public System.Enum val;

    public LuaEnum(string str, System.Enum v)
    {
        name = str;
        val = v;
    }
}*/

public class NoToLuaAttribute : System.Attribute
{
    public NoToLuaAttribute()
    {

    }
}

public class OnlyGCAttribute : System.Attribute
{
    public OnlyGCAttribute()
    {

    }
}

public class UseDefinedAttribute : System.Attribute
{
    public UseDefinedAttribute()
    {

    }
}


public interface ILuaWrap 
{
    void Register();
}

public class LuaStringBuffer
{
    //从lua端读取协议数据
    public LuaStringBuffer(IntPtr source, int len)
    {
        buffer = new byte[len];
        Marshal.Copy(source, buffer, 0, len);
    }

    //c#端创建协议数据
    public LuaStringBuffer(byte[] buf)
    {
        this.buffer = buf;
    }

    public byte[] buffer = null;
}

public class LuaRef
{
    public IntPtr L;
    public int reference;

    public LuaRef(IntPtr L, int reference)
    {
        this.L = L;
        this.reference = reference;
    }
}

/*一个发送协议的例子结构*/
public class MsgPacket
{
    public ushort id;
    public int      seq;
    public ushort   errno;        
    public LuaStringBuffer data;   
}
