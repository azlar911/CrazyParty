using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkController : NetworkManager {

    string sceneName;
    int[] roles = new int[4];
    int playerCount = 0;

    void Start()
    {
        for (int i = 0; i < roles.Length; i++)
            roles[i] = i;
    }

    static void shuffle(int[] arr)  // How the hell is this not in the standard library??
    {
        var rng = new System.Random();
        int n = arr.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            int tmp = arr[n];
            arr[n] = arr[k];
            arr[k] = tmp;
        }
    }

    public override void OnServerSceneChanged(string s)
    {
        sceneName = s;
        playerCount = 0;
        shuffle(roles);
        base.OnServerSceneChanged(s);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short id)
    {
        var gos = SceneManager.GetSceneByName(sceneName).GetRootGameObjects();
        var sl = System.Array.Find(gos, x => x.name.Equals("SceneLoader"));
        if (sl.name.Equals(""))
            Debug.LogError("Scene doesn't contain a SceneLoader game object");

        var loader = (SceneLoader)sl.GetComponent(typeof(SceneLoader));
        if (loader == null)
        {
            Debug.LogError("Game object doesn't contain a SceneLoader script");
            var player = (GameObject)GameObject.Instantiate(playerPrefab);
            NetworkServer.AddPlayerForConnection(conn, player, id);
        }
        else
        {
            var playerPrefab = loader.playerPrefabs[roles[playerCount++]];
            var player = (GameObject)GameObject.Instantiate(playerPrefab);
            NetworkServer.AddPlayerForConnection(conn, player, id);
        }
    }
}
