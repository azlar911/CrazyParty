using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneLoader : NetworkBehaviour {

    public GameObject[] playerPrefabs = new GameObject[4];

    public override void OnStartLocalPlayer()
    {
        foreach (var p in playerPrefabs)
            ClientScene.RegisterPrefab(p);
        Debug.Log("ClientScene.AddPlayer");
        ClientScene.AddPlayer(connectionToServer, 0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            ClientScene.AddPlayer(connectionToServer, 0);
    }

    void OnDestroy()
    {
        foreach (var p in playerPrefabs)
            ClientScene.UnregisterPrefab(p);
    }
}
