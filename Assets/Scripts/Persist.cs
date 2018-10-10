using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public struct Score
{
    int good, evil;
}

public class Persist : MonoBehaviour {

    static public Dictionary<string, Score> scoreboard;
    static public NetworkManager net;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Reset()
    {
        scoreboard = new Dictionary<string, Score>();
    }
}
