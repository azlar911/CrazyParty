using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Lobby : NetworkBehaviour
{
    void Start()
    {
        Persist.goodScores = new SyncListInt();
        Persist.evilScores = new SyncListInt();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && Persist.net.IsClientConnected())
            Persist.net.ServerChangeScene("LoadingNext");
    }
}
