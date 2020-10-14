using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    //damage player by this int
    public int dmgamt = 1;
  
    private void OnTriggerEnter(Collider other)
    {
        //player damage 
        if(other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<Health>().damage(dmgamt, hitDirection);
        }
    }
}
