﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkController : NetworkManager
{
    string sceneName;
    int[] roles = new int[4];

    object countLock = new object();
    int roleCount = 0;
    public int clientCount
    {
        get;
        private set;
    }

    int levelDoneCount = 0;

    int[] playerIds = { -1, -1, -1, -1 };

    static void Shuffle(int[] arr)  // How the hell is this not in the standard library??
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

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        lock (countLock)
        {
            // In game or full.
            if(sceneName != null || clientCount > 4)
            {
                conn.Disconnect();
                return;
            }
            clientCount++;
            playerIds[System.Array.IndexOf(playerIds, -1)] = conn.connectionId;
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        lock (countLock)
        {
            clientCount--;
            playerIds[System.Array.IndexOf(playerIds, conn.connectionId)] = -1;
        }
    }

    public override void OnServerSceneChanged(string s)
    {
        sceneName = s;

        roles = new int[clientCount];
        for (int i = 0; i < roles.Length; i++)
            roles[i] = i;
        
        Shuffle(roles);

        // Race condition if Unity doesn't ignore AddPlayer from earlier scenes.
        lock(countLock)
        {
            roleCount = 0;
            levelDoneCount = 0;
        }

        base.OnServerSceneChanged(s);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short id)
    {
        var gos = SceneManager.GetSceneByName(sceneName).GetRootGameObjects();
        var sl = System.Array.Find(gos, x => x.name.Equals("SceneLoader"));
        if (sl == null)
            Debug.LogError("Scene doesn't contain a SceneLoader game object");

        var loader = (SceneLoader)sl.GetComponent(typeof(SceneLoader));
        if (loader == null)
        {
            Debug.LogError("Game object doesn't contain a SceneLoader script");
            StartCoroutine(SpawnOnClientsReady(conn, playerPrefab, id, -1));    // Spawn default player prefab.
        }
        else
        {
            int i;
            lock (countLock)
            {
                i = roleCount++;
            }
            var playerPrefab = loader.playerPrefabs[roles[i]];
            StartCoroutine(SpawnOnClientsReady(conn, playerPrefab, id, roles[i]));
        }
    }

    IEnumerator SpawnOnClientsReady(NetworkConnection conn, GameObject playerPrefab, short id, int role)
    {
        while (true)
        {
            lock (countLock)
            {
                if (roleCount >= clientCount)
                    break;
            }
            yield return null;
        }
        
        var player = (GameObject)GameObject.Instantiate(playerPrefab);
        var pb = (PlayerBehaviour)player.GetComponent(typeof(PlayerBehaviour));
        pb.role = role;
        pb.playerId = playerIds[System.Array.IndexOf(playerIds, conn.connectionId)];
        pb.Init();
        NetworkServer.AddPlayerForConnection(conn, player, id);
    }

    public void ServerLevelDone()
    {
        lock(countLock)
        {
            levelDoneCount++;
            if (levelDoneCount >= clientCount)
                ServerChangeScene("LoadingNext");
        }
    }
}
