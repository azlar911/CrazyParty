using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public struct Score
{
    int good, evil;
}

public class Persist : NetworkBehaviour {

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    [SyncVar]
    public Score[] _scores;
    public NetworkManager _net = (NetworkManager)GameObject.Find("LobbyManager").GetComponent(typeof(NetworkManager));

    Persist self = (Persist)GameObject.Find("Persist");

    public Score[] scores
    {
        get => _scores;
        set => _scores = value;
    }

    public NetworkManager net => _net;
}
