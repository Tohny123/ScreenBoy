using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    
public Button[] levelButtons;
void Start ()
{
    int levelReached = PlayerPrefs.GetInt("levelReached", 1);
    for (int i = 0; i < levelButtons.Length; i++)
    {
        if (i + 1 > levelReached) 
        {
        levelButtons[i].interactable = false;
        }
    }
    Cursor.lockState = CursorLockMode.None;
}
public void gamestart(string LevelName)
{
SceneManager.LoadScene(LevelName);
}

}