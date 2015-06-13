using UnityEngine;
using System.Collections;
using LuaInterface;
using System;

public class LuaProtoBuffer01 : MonoBehaviour
{
    private string script = @"      
        function decoder()  
            local msg = person_pb.Person()
            msg:ParseFromString(TestProtol.data)
            print('id:'..msg.id..' name:'..msg.name..' email:'..msg.email)
        end

        function encoder()                           
            local msg = person_pb.Person()
            msg.id = 100
            msg.name = 'foo'
            msg.email = 'bar'
            local pb_data = msg:SerializeToString()
            TestProtol.data = pb_data
        end
        ";

    void Start()
    {
        LuaScriptMgr mgr = new LuaScriptMgr();
        mgr.Start();
        TestProtolWrap.Register(mgr.GetL());
        mgr.DoFile("person_pb.lua");
        mgr.DoString(script);

        LuaFunction func = mgr.GetLuaFunction("encoder");
        func.Call();
        func.Release();

        func = mgr.GetLuaFunction("decoder");
        func.Call();
        func.Release();
    }
}
