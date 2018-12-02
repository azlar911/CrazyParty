using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HitMoleController : PlayerBehaviour {

    public int numOfPlayer;

    public Vector2[] holePosition;
    public bool[] holeOccupied;
    public int[] hitMoleScore;

    public bool levelDone;
    // Use this for initialization
    void Start () {
        int i;
        for (i = 0; i < numOfPlayer; i++){
            hitMoleScore[i] = 0;
        }

        levelDone = false;
	}

    float Timer = 0;
	// Update is called once per frame
	void Update () {
        int i;
        if (!isLocalPlayer)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isLocalPlayer){

                Debug.Log(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name == "Mole(Clone)");
                    if (hit.collider.gameObject.name == "Mole(Clone)")
                    {

                        CmdDestroyMole(hit.collider.gameObject, this.role, this.playerId);
                        hitMoleScore[this.playerId]++;
                        //Persist.goodScores[this.playerId]++;
                    }
                }
            }
        }

        if (Input.touchCount > 0){
            for (i = 0; i < Input.touchCount; i++){
                if (isLocalPlayer)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);

                    if (hit.collider != null)
                    {
                        Debug.Log(hit.collider.gameObject.name == "Mole(Clone)");
                        if (hit.collider.gameObject.name == "Mole(Clone)")
                        {
                            CmdDestroyMole(hit.collider.gameObject, this.role, this.playerId);
                            hitMoleScore[this.playerId]++;
                            //Persist.goodScores[this.playerId]++;
                        }
                    }

                }
            }
        }

        Timer += Time.deltaTime;

        if(Timer > 10 && !levelDone)
        {
            Debug.Log(Timer);
            for (i = 0; i < numOfPlayer; i++)
            {
                //Persist.goodScores[i] += hitMoleScore[i];
                CmdAddScore(this.playerId, hitMoleScore[i]);
                Debug.Log(isLocalPlayer + "**" + i + ", " + hitMoleScore[i] + " " + Persist.goodScores[i]);
            }
            levelDone = true;
            LevelDone();

        }
    }

    [Command]
    void CmdDestroyMole(GameObject go, int thisRole, int thisPlayerId)
    {
        NetworkServer.Destroy(go);
    }

    [Command]
    void CmdAddScore(int thisPlayerId, int score)
    {
        Persist.goodScores[thisPlayerId] += score;
    }
}
