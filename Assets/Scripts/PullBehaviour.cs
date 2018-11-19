using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PullBehaviour : PlayerBehaviour
{
    float dir
    {
        get { return role % 2 == 0 ? 1 : -1; }
    }

    void Start()
    {
        transform.position += new Vector3(dir * 7, 0, 0);
    }

    float Timer;

    void Update()
    {
        if (!isLocalPlayer) {
            return;
            /*
            if (Input.GetMouseButtonDown(0))
            {
            Debug.Log(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name == "Mole(Clone)");
                    if (hit.collider.gameObject.tag == "rightPull" && dir == 1)
                    {
                        Cmdmove();
                    }
                    else if(hit.collider.gameObject.tag == "leftPull" && dir == -1)
                    {
                        Cmdmove();
                    }
                }
            }*/
        }

        
        Timer += Time.deltaTime;
        print("yee");
        print(Timer);

        if (Timer > 10)
        {
            LevelDone();
        }
        
    }
    void OnMouseDown()
    {
        GameObject.Find("rope").transform.position += new Vector3(dir/2, 0, 0);
    }
    /*
    [Command]
    void Cmdmove()
    {
        GameObject.Find("rope").transform.position += new Vector3(dir, 0, 0);
    }*/
}
