using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bgm : MonoBehaviour {
    [SerializeField] AudioSource bgm;
    [SerializeField] GameObject VoiceScrollButtom;
    private Scrollbar VoiceScrollBar;
    // Use this for initialization
    void Start () {
        bgm.Play();
        VoiceScrollButtom.SetActive(false);
        VoiceScrollBar = VoiceScrollButtom.GetComponent<Scrollbar>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetScrollBarActive()
    {
        if (VoiceScrollButtom.active==false)
        {
            VoiceScrollButtom.SetActive(true);
        }
        else
        {
            VoiceScrollButtom.SetActive(false);
        }
    }
    public void BgmPlayctrl()
    {
        if (VoiceScrollButtom.active == true)
        {
            bgm.volume= VoiceScrollBar.value;
        }
    }
}
