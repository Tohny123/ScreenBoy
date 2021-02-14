using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class healplr : MonoBehaviour
{
    public GameObject gameman;
    public Health health;
    public int healby;
    public GameObject parent;
    public GameObject particles;
    public AudioClip healsound;
    public float healvol;   
    // Start is called before the first frame update
    void Start()
    {
        gameman = GameObject.Find("GameManager");
        health = gameman.GetComponent<Health>();
        gameman.GetComponent<GameManager>().volnormal();
        healvol = gameman.GetComponent<GameManager>().vol;
        Debug.Log(healvol);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(healsound, transform.position, healvol);
            health.heal(healby);
            Destroy(parent);
            Instantiate(particles, transform.position, transform.rotation);
        }
    }
}
