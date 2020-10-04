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
    public int test;
    public PlayerData plrdata;
    public float volume;
    public bool fullscreen;
    void Start()
    { 
        
      load();
       
       
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
        
       test = plrdata.coinamount;

        
        healthdisplay = Health.currenthealth;
        healthtext.text = ("Health: " + healthdisplay);
        if (coinamount == null)
        {
            coinamount = 0;
        }
    }
    public void CoinAdd(int addcoin){
        coinamount += addcoin;
        cointext.text = ("Coins: " + coinamount);
    }
    public void save ()
    {
        SaveSystem.Save(this, filename);
        Debug.Log("Saved");
    }
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

