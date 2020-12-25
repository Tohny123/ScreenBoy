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
    public float tempvol;
    public AudioMixer audmix;
    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        //find health script
        healman = FindObjectOfType<Health>();
        audmix.GetFloat("Volume", out tempvol);
        checkvolume = 1/Mathf.Abs(tempvol);
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

