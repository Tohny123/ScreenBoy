using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void gamestart()
{
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}

}
