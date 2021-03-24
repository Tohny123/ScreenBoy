using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{

public GameObject fader;
public Fade fade;
public GameManager gameman = new GameManager();
public string filename;
public string[] levelnames;
public string levelchosen;
public static SaveSystem savesystem = new SaveSystem();
    public int coinamount;
    public int levelamount;
    public float rotationspeed;
    public float volume;
    public bool fullscreen;
    public bool watchedyet;

void Start()
{
    PlayerData data = SaveSystem.Load(gameman, filename);
        coinamount = data.coinamount;
        levelamount = data.levelamount;
        rotationspeed = data.rotationspeed;
        volume = data.volume;
        fullscreen = data.fullscreen;
        watchedyet = data.watchedyet;

    //find fader
    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();
    
    if(data.watchedyet == true)
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

}

