using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Health healman;
    public Renderer rend;
    public Material Checkoff;
    public Material Checkon;
    public AudioSource checkaudio;
    public AudioClip checksound;
    public float checkvolume;
    // Start is called before the first frame update
    void Start()
    {
        //find health script
       healman = FindObjectOfType<Health>();
    }
    public void checkpointon()
    {
        //make a new checkpoint array and disable each checkpoint
     Checkpoint[] checkarray = FindObjectsOfType<Checkpoint>();
     foreach (Checkpoint cp in checkarray)
     {
         cp.checkpointoff();
     }
        rend.material = Checkon;
    }
    //change checkpoint material
    public void checkpointoff()
    {
        rend.material = Checkoff;
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

