using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healplr : MonoBehaviour
{
    public GameObject gameman;
    public Health health;
    public int healby;
    public GameObject parent;
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        gameman = GameObject.Find("GameManager");
        health = gameman.GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health.heal(healby);
            Destroy(parent);
            Instantiate(particles, transform.position, transform.rotation);
        }
    }
}
