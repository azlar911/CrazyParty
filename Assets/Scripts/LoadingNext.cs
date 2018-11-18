using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadingNext : NetworkBehaviour
{
    void Update()
    {
        StartCoroutine(NextLevelIn(3));
    }

    IEnumerator NextLevelIn(float t)
    {
        yield return new WaitForSeconds(t);
        var s = Persist.levelScenes[new System.Random().Next(0, Persist.levelScenes.Count)];
        Persist.net.ServerChangeScene(s);
    }
}
