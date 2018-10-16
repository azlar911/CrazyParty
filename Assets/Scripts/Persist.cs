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
        _net = (NetworkManager)this.gameObject.GetComponent(typeof(NetworkManager));
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    SyncListInt _goodScores;
    SyncListInt _evilScores;
    NetworkManager _net;

    static Persist instance;

    static public SyncListInt goodScores
    {
        get
        {
            return instance._goodScores;
        }
        set
        {
            instance._goodScores = value;
        }
    }

    static public SyncListInt evilScores
    {
        get
        {
            return instance._evilScores;
        }
        set
        {
            instance._evilScores = value;
        }
    }

    static public NetworkManager net
    {
        get
        {
            return instance._net;
        }
    }
}
