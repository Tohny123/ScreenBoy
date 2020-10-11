using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();

    }

    public void dialoguestart (Dialogue dialogue) 
    {
        Debug.Log(dialogue.name);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        displaysentence();
    }
   
   public void displaysentence()
   {
       if (sentences.Count == 0)
       {
           enddialogue();
           return;
       }
       string sentence = sentences.Dequeue();
       Debug.Log(sentence);
   }
    void enddialogue()
    {
        Debug.Log("end");
    }
}
