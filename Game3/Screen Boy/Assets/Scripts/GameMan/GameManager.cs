using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int coinamount;
    public Text cointext;
    public int healthdisplay;
    public Text healthtext;
    void Start()
    {
        
    }

  
    void Update()
    {
        healthdisplay = Health.currenthealth;
        healthtext.text = ("Health: " + healthdisplay);
    }
    public void CoinAdd(int addcoin){
        coinamount += addcoin;
        cointext.text = ("Coins: " + coinamount);
    }

}

