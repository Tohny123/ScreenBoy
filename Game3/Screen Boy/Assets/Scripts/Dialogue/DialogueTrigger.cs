using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueman;
    public bool enabled;
    void Start ()
    {
        enabled = true;
        dialogueman = FindObjectOfType<DialogueManager>();
    }

    public void triggerdialogue ()
    {
       dialogueman.dialoguestart(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(enabled == true)
            {
                triggerdialogue();
                enabled = false;
            }
            
        }
    }
    
}
