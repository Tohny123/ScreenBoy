using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject plr;
    void Awake()
    {
    plr = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            plr.transform.parent = transform;
            plr.transform.position = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            plr.transform.parent = null;
        }
    }
}
