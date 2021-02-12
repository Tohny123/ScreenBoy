using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public static bool gamepause;
    public GameObject pauseui;
    public GameObject CameraRef;
    public string MenuString;
    public GameObject fader;
    public Fade fade;

    void Start()
    {
        //find fader
        fader = GameObject.Find("Fade");
        fade = fader.GetComponent<Fade>();
        //set time
        Time.timeScale = 1f;
        //make pause game false
        gamepause = false;
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        //deactivate pauseui
        pauseui.SetActive(false);
        //find camera
        CameraRef = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //find if player presses escape
       
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gamepause)
                {
                    //resume
                    ResumeGame();
                    Cursor.lockState = CursorLockMode.Locked;
                } else
                {
                        //pause
                        PauseGame();
                }
            }
        
    }

public void ResumeGame () 
{
//resume
Cursor.lockState = CursorLockMode.Locked;
CameraRef.GetComponent<Camera>().enabled = true;
pauseui.SetActive(false);
Time.timeScale = 1f;
gamepause = false;
}
void PauseGame () 
{
//pause
Cursor.lockState = CursorLockMode.None;
CameraRef.GetComponent<Camera>().enabled = false;
pauseui.SetActive(true);
Time.timeScale = 0f;
gamepause = true;
}
public void MenuLoad()
{
    //load menu
    ResumeGame();
    StartCoroutine(fade.LevelFade(MenuString));
    Cursor.lockState = CursorLockMode.None;
}

public void QuitGame()
{
    //quit game
    Debug.Log("Quit");
    Application.Quit();
}

}



