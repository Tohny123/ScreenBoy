using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Checkpoint : MonoBehaviour
{
    public Health healman;
    public Renderer rend;
    public Material Checkoff;
    public Material Checkon;
    public AudioSource checkaudio;
    public AudioClip checksound;
    public float checkvolume;
    public GameObject model;
    public GameManager gameman;
    // Start is called before the first frame update
    void Start()
    {
        //find health script
        healman = FindObjectOfType<Health>();
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameman.volnormal();
        checkvolume = gameman.vol;
        Debug.Log(checkvolume);
    }
    public void checkpointon()
    {
        //make a new checkpoint array and disable each checkpoint
     Checkpoint[] checkarray = FindObjectsOfType<Checkpoint>();
     foreach (Checkpoint cp in checkarray)
     {
         cp.checkpointoff();
     }
        model.GetComponent<Renderer>().material = Checkon;
    }
    //change checkpoint material
    public void checkpointoff()
    {
        model.GetComponent<Renderer>().material = Checkoff;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //enable checkpoint
        if (other.tag == "Player")
        {
            checkaudio.PlayOneShot(checksound, checkvolume);
            healman.setspawn(transform.position);
            checkpointon();
        }
    }  
}

