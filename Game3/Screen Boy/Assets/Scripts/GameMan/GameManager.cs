using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameManager : MonoBehaviour
{
    public int coinamount;
    public Text cointext;
    public int healthdisplay;
    public Text healthtext;
    public static SaveSystem savesystem = new SaveSystem();
    public string filename;
    public int levelamount;
    public LevelWin levlwin;
    public float rotspd;
    //public int test;
    public PlayerData plrdata;
    public float volume;
    public bool fullscreen;
    void Start()
    { 
        //load save data  
        load();
       //lock cursor
       Cursor.lockState = CursorLockMode.Locked;
       //coin text
        if (coinamount > 0)
        {
        cointext.text = ("Coins: " + coinamount);
        }
        else
        {
        cointext.text = ("Coins: 0");
        }
    }

  
    void Update()
    {
        
       //test = plrdata.coinamount;
        //heath ui
        healthdisplay = Health.currenthealth;
        healthtext.text = ("Health: " + healthdisplay);
        //fix null values
        if (coinamount == null)
        {
            coinamount = 0;
        }
    }
    //add coins
    public void CoinAdd(int addcoin){
        coinamount += addcoin;
        cointext.text = ("Coins: " + coinamount);
    }
    //activate save system save 
    public void save ()
    {
        SaveSystem.Save(this, filename);
        Debug.Log("Saved");
    }
    //save system load
    public void load ()
    {
        PlayerData data = SaveSystem.Load(this, filename);
        coinamount = data.coinamount;
        levelamount = data.levelamount;
        rotspd = data.rotationspeed;
        volume = data.volume;
        fullscreen = data.fullscreen;
        Debug.Log("Loading");
    }

}

