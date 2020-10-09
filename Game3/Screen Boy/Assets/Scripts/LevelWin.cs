using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class LevelWin : MonoBehaviour
{
    public string nextlevel;
    public int unlockedlevel;
    public GameManager gameman;
    public PlayerData plrdata;
    public string LevlNam;
    public GameObject fader;
    public Fade fade;
    public float life;
    public GameObject usb;
    public GameObject winlevel;
    public AudioClip win;
    public AudioMixer audmix;
    public float tempvol;
    public float vol;
    void Start()
    {
    audmix.GetFloat("Volume", out tempvol);
    vol = 1/Mathf.Abs(tempvol);
    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();
    winlevel = GameObject.Find("LevelWin");
    usb = winlevel.transform.Find("USB").gameObject;
    }
    
    private void OnTriggerEnter(Collider other)
    {
     
        if(other.gameObject.tag == "Player")
        {
            int levl = unlockedlevel - 1;
            if (gameman.levelamount < levl)
            {
                gameman.levelamount = levl;
                plrdata.levelamount = levl;  
                
            }
            AudioSource.PlayClipAtPoint(win, transform.position, vol);
            gameman.save();
            Destroy(usb, life);
            StartCoroutine(fade.LevelFade(LevlNam));
        }
        

    }
}
