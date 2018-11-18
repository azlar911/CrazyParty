using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour
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

    bool levelDone = false;

    public void LevelDone()
    {
        if (!levelDone)
        {
            levelDone = true;
            CmdLevelDone();
        }
    }

    [Command]
    void CmdLevelDone()
    {
        Persist.net.ServerLevelDone();
    }
}
