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
        fader = GameObject.Find("Fade");
        fade = fader.GetComponent<Fade>();
        Time.timeScale = 1f;
        gamepause = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseui.SetActive(false);
        CameraRef = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamepause)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }
public void ResumeGame () 
{
Cursor.lockState = CursorLockMode.Locked;
CameraRef.GetComponent<Camera>().enabled = true;
pauseui.SetActive(false);
Time.timeScale = 1f;
gamepause = false;
}
void PauseGame () 
{
Cursor.lockState = CursorLockMode.None;
CameraRef.GetComponent<Camera>().enabled = false;
pauseui.SetActive(true);
Time.timeScale = 0f;
gamepause = true;
}
public void MenuLoad()
{
    ResumeGame();
   StartCoroutine(fade.LevelFade(MenuString));
   Cursor.lockState = CursorLockMode.None;
}

public void QuitGame()
{
    Debug.Log("Quit");
Application.Quit();
}

}



