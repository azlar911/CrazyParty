using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingNext : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(NextLevelIn(0));
        else if(Input.GetKeyDown(KeyCode.P))
            NextLevelIn(3);
    }

    IEnumerator NextLevelIn(float t)
    {
        yield return new WaitForSeconds(t);
        var s = Persist.gameScenes[new System.Random().Next(0, Persist.gameScenes.Length)];
        Persist.net.ServerChangeScene(s);
    }
}
