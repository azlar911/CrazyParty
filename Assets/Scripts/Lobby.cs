using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Lobby : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] GameObject VoiceScrollButtom;
    [SerializeField] Scrollbar VoiceScrollBar;
    void Start()
    {
        VoiceScrollButtom.SetActive(false);
        VoiceScrollBar = VoiceScrollButtom.GetComponent<Scrollbar>();
        bgm.Play();
    }
    
    void Update()
    {
        // TODO: check host
       
    }
    public void PlayButtomDown()
    {
        bgm.Stop();
        if (Persist.net.IsClientConnected())
        {
            Persist.goodScores = new SyncListInt();
            Persist.evilScores = new SyncListInt();
            Persist.net.ServerChangeScene("LoadingNext");
        }
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
    public void BackButtonDown()
    {
        bgm.Stop();
        SceneManager.LoadScene("MainMenu");
    }
}
