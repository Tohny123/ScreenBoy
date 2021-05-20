using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{

public GameObject fader;
public Fade fade;
public GameManager gameman;
public string filename;
public string[] levelnames;
public string levelchosen;
public static SaveSystem savesystem = new SaveSystem();
    public bool watchedyet;

void Start()
{
    

    //find fader
    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();
    
    if (gameman.watchedyet == true)
    {
        levelchosen = levelnames[0];
    }
    else
    {
        levelchosen = levelnames[1];
    }
}
public void gamestart(string LevelName)
{
StartCoroutine(fade.LevelFade(LevelName));
}

public void startif()
{
StartCoroutine(fade.LevelFade(levelchosen));

}
public void load()
{
PlayerData data = SaveSystem.Load(gameman, filename);
        gameman.coinamount = data.coinamount;
        gameman.levelamount = data.levelamount;
        gameman.rotspd = data.rotationspeed;
        gameman.volume = data.volume;
        gameman.fullscreen = data.fullscreen;
        gameman.watchedyet = data.watchedyet;
}

}

