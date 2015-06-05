using UnityEngine;
using System.Collections;
using LuaInterface;

public class CreateGameObject02 : MonoBehaviour {

    private string script = @"
            luanet.load_assembly('UnityEngine')
            GameObject = UnityEngine.GameObject
            local newGameObj = GameObject('NewObj')
            newGameObj:AddComponent('ParticleSystem')
        ";

	//非反射调用
	void Start () {
        LuaScriptMgr lua = new LuaScriptMgr();
        lua.Start();
        lua.DoString(script);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
