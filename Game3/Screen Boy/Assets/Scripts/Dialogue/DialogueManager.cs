using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Queue<string> sentences;
    public GameObject ui;
    public GameObject dialogueui;
    public Animator dialogueanim;
    public GameObject charname;
    public GameObject spoken;
    public GameObject cameraref;   
    public Text charnametext;
    public Text spokentext; 
    // Awake is called before the first frame update
    void Awake()
    {
        //find camera
        cameraref = GameObject.Find("Main Camera");
        //initialize sentences
        sentences = new Queue<string>();
        //find ui
        ui = GameObject.Find("UI");
        dialogueui = ui.transform.Find("Dialogue").gameObject;
        charname = dialogueui.transform.Find("Name").gameObject;
        charnametext = charname.GetComponent<Text>();
        spoken = dialogueui.transform.Find("Text").gameObject;
        spokentext = spoken.GetComponent<Text>();
        dialogueanim = dialogueui.GetComponent<Animator>();
    }

    public void dialoguestart (Dialogue dialogue) 
    {
        //start dialogue
        Cursor.lockState = CursorLockMode.None;
        cameraref.GetComponent<Camera>().enabled = false;
        dialogueanim.SetBool("IsActive", true);
        charnametext.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        displaysentence(sentences);
    }
   
   public void displaysentence (Queue<string> queue)
   {
       //show sentences
       if (queue.Count == 0)
       {
           enddialogue();
           return;
       }
       string sentence = queue.Dequeue();
       spokentext.text = sentence;
   }
    void enddialogue()
    {
        //reset dialogue state
        Cursor.lockState = CursorLockMode.Locked;
        cameraref.GetComponent<Camera>().enabled = true;
        dialogueanim.SetBool("IsActive", false);
    }
    
}
