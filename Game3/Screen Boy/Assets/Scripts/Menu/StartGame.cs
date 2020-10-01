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
    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();
}
public void gamestart(string LevelName)
{
StartCoroutine(fade.LevelFade(LevelName));
}


}
