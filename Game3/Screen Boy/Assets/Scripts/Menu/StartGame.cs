using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{

public GameObject fader;
public Fade fade;

void Start()
{
    //find fader
    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();
}
public void gamestart(string LevelName)
{
//load level
StartCoroutine(fade.LevelFade(LevelName));
}


}
