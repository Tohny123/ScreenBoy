using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject plr;
    public NavMeshAgent agent;
    private Vector3 plrlocation;
    public float radius;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //find player
        plr = GameObject.Find("Player");
    
    }

    // Update is called once per frame
    void Update()
    {
        //find distance between enemy and player
        plrlocation = plr.transform.position;
        float distance = Vector3.Distance(plrlocation, transform.position);
        //animation
        anim.SetFloat("Speed", (Mathf.Abs(agent.velocity.x)) + (Mathf.Abs(agent.velocity.y)));
        //if player is in the radius chase after player
        if(distance <= radius)
        {
            agent.SetDestination(plrlocation);
        }
        
    }
}
