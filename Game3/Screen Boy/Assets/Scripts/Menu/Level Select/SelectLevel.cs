using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public int? levelReached;
    public PlayerData plrdata;
public Button[] levelButtons;
void Start ()
{
   levelReached = plrdata.levelamount;
    for (int i = 0; i < levelButtons.Length; i++)
    {
        if (i + 1 > levelReached) 
        {
        levelButtons[i].interactable = false;
        }
    }
    Cursor.lockState = CursorLockMode.None;
}
void Update()
{
    levelReached = plrdata.levelamount;
}


}