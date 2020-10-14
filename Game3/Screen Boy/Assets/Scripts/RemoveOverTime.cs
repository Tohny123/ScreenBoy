using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOverTime : MonoBehaviour
{
    public float life;
   
    // Update is called once per frame
    void Update()
    {
        //remove object depending on its life
       Destroy(gameObject, life);
    }
}
