using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class easteregg : MonoBehaviour
{
    public string lvl;
    private void OnTriggerEnter(Collider other)
    {
        //when player enters deal damage
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvl);
        }
    }
}
