using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public GameObject parent;
    public GameObject Health;
    public GameObject particles;
    public float inv;
    public AudioClip enemydeath;
    // Start is called before the first frame update
    void Start()
    {
     Health = GameObject.Find("GameManager");
     
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
               AudioSource.PlayClipAtPoint(enemydeath, transform.position, 1f);
               Instantiate(particles, transform.position, transform.rotation);
               Destroy(parent);
           }
            
        }
    }
}
