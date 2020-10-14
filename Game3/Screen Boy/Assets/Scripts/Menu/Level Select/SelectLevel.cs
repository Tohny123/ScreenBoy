using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SelectLevel : MonoBehaviour
{
    public int levelReached;
    public PlayerData plrdata;
    public GameManager gameman;
    public Button[] levelButtons;
    public string filename;
    public static SaveSystem savesys = new SaveSystem();
    public GameObject fader;
    public Fade fade;
   // public int test;

void Start ()
{
    //find fader
    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();
    //load player data
    load();
    //make levels uninteractable
    for (int i = 0; i < levelButtons.Length; i++)
    {
        
        if (i > levelReached) 
        {
        levelButtons[i].interactable = false;
        }
    }
    Cursor.lockState = CursorLockMode.None;
}
//save
public void save()
{
SaveSystem.Save(gameman, filename);
}
//load
public void load()
{
SaveSystem.Load(gameman, filename);
PlayerData data = SaveSystem.Load(gameman, filename);
levelReached = data.levelamount;
}
//load level
public void LoadLevel(string loadedlevel)
{
StartCoroutine(fade.LevelFade(loadedlevel));
}

}