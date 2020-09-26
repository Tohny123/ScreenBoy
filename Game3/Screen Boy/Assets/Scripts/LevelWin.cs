using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    public string nextlevel;
    public int unlockedlevel;
    public GameManager gameman;
    public PlayerData plrdata;
    
    
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
            gameman.save();
          
            SceneManager.LoadScene("Level Select");
        }
        

    }
}
