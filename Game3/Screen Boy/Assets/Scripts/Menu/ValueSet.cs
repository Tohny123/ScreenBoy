using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSet : MonoBehaviour
{
    public static SaveSystem savesystem = new SaveSystem();
    public static GameManager gameman = new GameManager();    
    public string filename;
    public int coinamount;
    public int levelamount;
    public float rotationspeed;
    public float volume;
    public bool fullscreen;
    
    void Start()
    {
        load();
        if(rotationspeed == 0)
        {
            rotationspeed = 10;
        }
        if(volume == 0)
        {
            volume = 1;
        }
    }

    public void load()
    {
        PlayerData data = SaveSystem.Load(gameman, filename);
        coinamount = data.coinamount;
        levelamount = data.levelamount;
        rotationspeed = data.rotationspeed;
        volume = data.volume;
        fullscreen = data.fullscreen;
        Debug.Log("Loading");        
    }

    public void save ()
    {
        SaveSystem.Save(gameman, filename);
        Debug.Log("Saved");        
    }


}
