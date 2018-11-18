using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bug : MonoBehaviour {

    public static void Splat()
    {
        SceneManager.LoadScene("BugSplat");
    }
}
