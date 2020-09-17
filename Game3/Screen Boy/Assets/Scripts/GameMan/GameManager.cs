﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int? coinamount;
    public Text cointext;
    public int healthdisplay;
    public Text healthtext;
    public static SaveSystem savesystem = new SaveSystem();
    public string filename = savesystem.filename;
    
    void Start()
    { 
      
        load();
        cointext.text = ("Coins: " + coinamount);
    }

  
    void Update()
    {
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
        SaveSystem.SaveCoin(this, filename);
        Debug.Log("Saved");
    }
    public void load ()
    {
        PlayerData data = SaveSystem.LoadCoin(filename);
        coinamount = data.coinamount;
        Debug.Log("Loading");
    }

}

