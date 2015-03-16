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

public interface ILuaWrap 
{
    void Register();
}

public class LuaStringBuffer
{
    public LuaStringBuffer(IntPtr source, int len)
    {
        buffer = new byte[len];
        Marshal.Copy(source, buffer, 0, len);
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
//在lua中得到MsgPacket对象msg，然后local data = msg:PushLuaString() 获取数据缓冲区
//之后是lua对应协议对象调用 ParseFromString(data)
public class MsgPacket
{
    //包头
    public ushort id;       //协议id
    public int seq;         //协议 sequence id
    public ushort errno;    //错误码

    //包数据
    public byte[] data;     //协议数据

    public void PushLuaString(IntPtr L)
    {
        if (data != null)
        {
            LuaDLL.lua_pushlstring(L, data, data.Length);
        }
        else
        {
            LuaDLL.lua_pushnil(L);
        }

    }
}