using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneLoader : NetworkBehaviour {

    public GameObject[] playerPrefabs = new GameObject[4];

    void Start()
    {
        foreach (var p in playerPrefabs)
            ClientScene.RegisterPrefab(p);

        Debug.Log("ClientScene.AddPlayer");
        ClientScene.AddPlayer(connectionToServer, 0);
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;
    }

    void OnDestroy()
    {
        foreach (var p in playerPrefabs)
            ClientScene.UnregisterPrefab(p);
    }
}
