using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNext : MonoBehaviour
{
    public GameObject dialogueobject;
    public DialogueTrigger diatrig;
    public Queue<string> sentences;
    
    void Start ()
    {
    //find dialoguetrigger
    dialogueobject = GameObject.Find("DialogueTrigger");
    diatrig = dialogueobject.GetComponent<DialogueTrigger>();
    }
    public void nextbutton ()
    {   
        //display sentences
        sentences = diatrig.dialogueman.sentences;
        diatrig.dialogueman.displaysentence(sentences);
        diatrig.dialogueman.sentences = sentences;
    }
}
