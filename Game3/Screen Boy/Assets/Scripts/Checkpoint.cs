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
       healman = FindObjectOfType<Health>();
    }
    public void checkpointon()
    {
     Checkpoint[] checkarray = FindObjectsOfType<Checkpoint>();
     foreach (Checkpoint cp in checkarray)
     {
         cp.checkpointoff();
     }
        rend.material = Checkon;
    }
    public void checkpointoff()
    {
        rend.material = Checkoff;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            checkaudio.PlayOneShot(checksound, checkvolume);
            healman.setspawn(transform.position);
            checkpointon();
        }
    }  
}

