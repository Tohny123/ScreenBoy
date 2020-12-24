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
    public GameObject plrobj;
    public Player plr;
    public float bounceheight;
    // Start is called before the first frame update
    void Start()
    {
    //find objects
    Health = GameObject.Find("GameManager");
    plrobj = GameObject.Find("Player");
    plr = plrobj.GetComponent<Player>();
    audmix.GetFloat("Volume", out tempvol);
    vol = 1/Mathf.Abs(tempvol+1);


    }

    // Update is called once per frame
    void Update()
    {
    //make inv player invincibillity
     inv = Health.GetComponent<Health>().invcount;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           if (inv < 0)
           {
               //make it so that the enemy only dies when player is not invincable
               AudioSource.PlayClipAtPoint(enemydeath, transform.position, vol);
               Instantiate(particles, transform.position, transform.rotation);
               Destroy(parent);
               plr.V3.y = bounceheight;
           }
            
        }
    }
}
