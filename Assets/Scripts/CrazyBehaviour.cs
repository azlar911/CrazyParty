using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CrazyBehaviour : NetworkBehaviour
{

    public int role
    {
        get;
        private set;
    }


    [ClientRpc]
    public void RpcSetRole(int i)
    {
        role = i;
    }
}
