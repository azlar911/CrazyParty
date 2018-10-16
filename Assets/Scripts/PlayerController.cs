using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    [SyncVar]
    public int role;    // Variable indicating which role should the player play.
                        // It's meaning depends on the particular scene.
     
    [ClientRpc]
    void RpcRole(int r)
    {
        role = r;
    }

    static public PlayerController localPlayer
    {
        get
        {
            var gos = GameObject.FindGameObjectsWithTag("Player");
            foreach (var go in gos)
            {
                var p = (PlayerController)go.GetComponent(typeof(PlayerController));
                if (p.isLocalPlayer)
                    return p;
            }
            return null;
        }
    }

	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 10f;

        transform.Translate(x, y, 0);

        if(Input.GetKeyDown(KeyCode.P))
        {
        }
    }

    [Command]
    public void CmdSpawn(GameObject prefab)
    {
        var go = (GameObject)Instantiate(prefab);
        Destroy(gameObject);
        NetworkServer.ReplacePlayerForConnection(connectionToClient, go, 0);
    }
}
