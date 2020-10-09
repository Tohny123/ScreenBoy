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
        plr = GameObject.Find("Player");
    
    }

    // Update is called once per frame
    void Update()
    {
        plrlocation = plr.transform.position;
        float distance = Vector3.Distance(plrlocation, transform.position);
        anim.SetFloat("Speed", (Mathf.Abs(agent.velocity.x)) + (Mathf.Abs(agent.velocity.y)));
        if(distance <= radius)
        {
            agent.SetDestination(plrlocation);
        }
        
    }
}
