using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject plr;
    public NavMeshAgent agent;
    private Vector3 plrlocation;
    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.Find("Player");
        plrlocation = plr.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        plrlocation = plr.transform.position;
        agent.SetDestination(plrlocation);
    }
}
