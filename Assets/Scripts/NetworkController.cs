using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

class PlayerData
{
    public PlayerData(NetworkConnection conn, short id, GameObject go)
    {
        this.conn = conn;
        this.id = id;
        this.go = go;
    }

    public NetworkConnection conn;
    public short id;
    public GameObject go;
}

public class NetworkController : NetworkManager {

    List<PlayerData> pds;

	public override void OnServerSceneChanged(string sceneName)
    {
        var scene = SceneManager.GetSceneByName(sceneName);
        var gos = scene.GetRootGameObjects();
        var loader = (SceneLoader)System.Array.Find(gos, x => x.name.Equals("SceneLoader")).GetComponent(typeof(SceneLoader));
        int i = 0;
        foreach(var pd in pds)
        {
            var player = (GameObject)GameObject.Instantiate(loader.PrefabFor(i));
            Destroy(pd.go);
            pd.go = player;
            i++;
        }
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short id)
    {
        var player = (GameObject)GameObject.Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player, id);
        pds.Add(new PlayerData(conn, id, player));
    }
}
