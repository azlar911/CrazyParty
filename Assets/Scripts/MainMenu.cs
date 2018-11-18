using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {
    [HideInInspector] public  static AudioSource  bgm;
    [SerializeField] GameObject VoiceScrollButtom;
    private Scrollbar VoiceScrollBar;
    // Use this for initialization
    void Start () {
        bgm = gameObject.GetComponent<AudioSource>();
        bgm.Play();
        VoiceScrollButtom.SetActive(false);
        VoiceScrollBar = VoiceScrollButtom.GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {
   
    }
    public void PlayButtomDown(){
        bgm.Stop();
        SceneManager.LoadScene("Lobby");
    }
    public void SetScrollBarActive()
    {
        if (VoiceScrollButtom.active == false)
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
            bgm.volume = VoiceScrollBar.value;
        }
    }
   
}
