using UnityEngine;
using System.Collections;
using LuaInterface;

public class CreateGameObject : MonoBehaviour {

    private string script = @"
            luanet.load_assembly('UnityEngine')
            GameObject = luanet.import_type('UnityEngine.GameObject')

            local newGameObj = GameObject('NewObj')
            newGameObj:AddComponent('ParticleSystem')
        ";

	// Use this for initialization
	void Start () {
        LuaState l = new LuaState();
        l.DoString(script);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
