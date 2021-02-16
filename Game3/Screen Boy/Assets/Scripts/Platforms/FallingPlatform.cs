using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public GameObject parent;
    public Animator anim;
    public Collider boxcol;
    public Renderer rend;
    public int layerindex;
    public int recovertime;
    public float test;
    public float dissapeartime;
    public GameObject particles;
    void Start()
    {
        anim = parent.GetComponent<Animator>();
        boxcol = parent.GetComponent<Collider>();
        layerindex = anim.GetLayerIndex("Base Layer");
        rend = parent.GetComponent<Renderer>();
        dissapeartime = anim.GetCurrentAnimatorStateInfo(layerindex).length;


    }
    void Update()
    {
        dissapeartime = anim.GetCurrentAnimatorStateInfo(layerindex).length;
    }
    private void OnTriggerEnter(Collider other)
    {
        //when player enters deal damage
        if(other.gameObject.tag == "Player")
        {
            
            StartCoroutine(Dissapear());
        }
    }
    public IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(recovertime);
        anim.SetTrigger("Dissapear");
        yield return new WaitForSeconds(recovertime);
        boxcol.enabled = false;
        rend.enabled = false;
        yield return new WaitForSeconds(recovertime);
        anim.SetTrigger("Appear");
        boxcol.enabled = true;
        rend.enabled = true;
    }
}
