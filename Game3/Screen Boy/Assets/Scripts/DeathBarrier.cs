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
    //find gamemanager then get health component
    gameman = GameObject.Find("GameManager");
    heal = gameman.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //set damage amount to equal player health
       death = heal.deathbarrierhealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        //when player enters deal damage
        if(other.gameObject.tag == "Player")
        {
            Vector3 dead = other.transform.position - transform.position;
            dead = dead.normalized;
            FindObjectOfType<Health>().damage(death, dead);
        }
    }
}
