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

    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();

    load();

    for (int i = 0; i < levelButtons.Length; i++)
    {
        
        if (i > levelReached) 
        {
        levelButtons[i].interactable = false;
        }
    }
    Cursor.lockState = CursorLockMode.None;
}
public void save()
{
SaveSystem.Save(gameman, filename);
}
public void load()
{
SaveSystem.Load(gameman, filename);
PlayerData data = SaveSystem.Load(gameman, filename);
levelReached = data.levelamount;
}

public void LoadLevel(string loadedlevel)
{

StartCoroutine(fade.LevelFade(loadedlevel));
}
void Update()
{
   
}


}