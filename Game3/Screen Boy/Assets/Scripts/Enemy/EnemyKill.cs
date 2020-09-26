using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyKill : MonoBehaviour
{
    public GameObject parent;
    public GameObject Health;
    public GameObject particles;
    public float inv;
    public AudioClip enemydeath;
    public AudioMixer audmix;
    public float vol;
    public float tempvol;
    // Start is called before the first frame update
    void Start()
    {
     Health = GameObject.Find("GameManager");
    
    audmix.GetFloat("Volume", out tempvol);
    vol = 1/Mathf.Abs(tempvol);


    }

    // Update is called once per frame
    void Update()
    {
     inv = Health.GetComponent<Health>().invcount;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           if (inv < 0)
           {
               AudioSource.PlayClipAtPoint(enemydeath, transform.position, vol);
               Instantiate(particles, transform.position, transform.rotation);
               Destroy(parent);
           }
            
        }
    }
}
