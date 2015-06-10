using UnityEngine;
using System.Collections;
using LuaInterface;

public class CreateGameObject01 : MonoBehaviour {

    private string script = @"
            luanet.load_assembly('UnityEngine')
            GameObject = luanet.import_type('UnityEngine.GameObject')        
	    ParticleSystem = luanet.import_type('UnityEngine.ParticleSystem')            
            local newGameObj = GameObject('NewObj')
            newGameObj:AddComponent(luanet.ctype(ParticleSystem))
        ";

	//反射调用
	void Start () {
        LuaState lua = new LuaState();
        lua.DoString(script);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
