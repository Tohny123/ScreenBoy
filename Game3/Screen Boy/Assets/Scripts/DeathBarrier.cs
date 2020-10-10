using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public int death;
    public GameObject gameman;
    public Health heal;
    
    // Start is called before the first frame update
    void Start()
    {
    gameman = GameObject.Find("GameManager");
    heal = gameman.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
       death = heal.deathbarrierhealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 dead = other.transform.position - transform.position;
            dead = dead.normalized;
            FindObjectOfType<Health>().damage(death, dead);
        }
    }
}
