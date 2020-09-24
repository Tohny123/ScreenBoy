using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    public string nextlevel;
    public int unlockedlevel;
    public GameManager gameman;
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level Select");
            if (gameman.levelamount < unlockedlevel)
            {
                gameman.levelamount = unlockedlevel;  
                
            }
        }
        

    }
}
