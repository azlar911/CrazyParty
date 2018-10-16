using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 10f;

        transform.Translate(x, y, 0);
    }

    [Command]
    public void CmdRespawn(GameObject prefab)
    {
        var go = (GameObject)Instantiate(prefab);
        Destroy(gameObject);
        NetworkServer.ReplacePlayerForConnection(connectionToClient, go, 0);
    }
}
