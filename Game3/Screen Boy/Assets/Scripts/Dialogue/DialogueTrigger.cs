using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject cameraref;
    public void triggerdialogue ()
    {
        FindObjectOfType<DialogueManager>().dialoguestart(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0f;
            triggerdialogue();
            Cursor.lockState = CursorLockMode.None;
            cameraref.GetComponent<Camera>().enabled = false;
        }
    }
}
