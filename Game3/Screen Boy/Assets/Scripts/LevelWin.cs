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

    public float vol;
    void Start()
    {
    //get components
    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();
    winlevel = GameObject.Find("LevelWin");
    usb = winlevel.transform.Find("USB").gameObject;
    gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
    //set volume
    gameman.volnormal();
    vol = gameman.vol;
    }
    
    private void OnTriggerEnter(Collider other)
    {
     
        if(other.gameObject.tag == "Player")
        {
            //set level amount
            int levl = unlockedlevel - 1;
            if (gameman.levelamount < levl)
            {
                gameman.levelamount = levl;
                plrdata.levelamount = levl;  
                
            }
            //play audio, save, and destroy object
            AudioSource.PlayClipAtPoint(win, transform.position, vol);
            gameman.save();
            Destroy(usb, life);
            //fade
            StartCoroutine(fade.LevelFade(LevlNam));
        }
        

    }
}
