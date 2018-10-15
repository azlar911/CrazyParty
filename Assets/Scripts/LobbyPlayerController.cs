using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyPlayerController : NetworkBehaviour {

    public GameObject prefab;

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
            CmdSpawn();
        }
    }

    [Command]
    void CmdSpawn()
    {
        var go = (GameObject)Instantiate(prefab, new Vector3(0, 1, 0), Quaternion.identity);
        Destroy(gameObject);
        NetworkServer.ReplacePlayerForConnection(connectionToClient, go, 0);
    }
}
