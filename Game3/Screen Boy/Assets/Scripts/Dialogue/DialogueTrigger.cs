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
        //make enabled true, enabled makes sure that you can't trigger dialogue twice
        enabled = true;
        //find dialogue manager
        dialogueman = FindObjectOfType<DialogueManager>();
    }

    public void triggerdialogue ()
    {
        //start dialogue using the triggers dialogue
       dialogueman.dialoguestart(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(enabled == true)
            {
                //trigger when player colides with object
                triggerdialogue();
                enabled = false;
            }
            
        }
    }
    
}
