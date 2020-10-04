using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
public LayerMask floor;
public float speed;
public float jumpheight;
public float gravityspeed;
public Animator anim;
public float rotspeed;
public Transform pivot;
public CharacterController contrl;
public float kb;
public float kbtime;
private float kbcount;
public GameObject model;
public AudioSource audio;
public AudioClip jumpsound;
public float jumpvolume;
private Vector3 V3;
public GameObject gamemanager;
public GameManager gameman;
void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        gameman = gamemanager.GetComponent<GameManager>();
        contrl = GetComponent<CharacterController>();
      
    }

void Update()
    { 
        if(kbcount <= 0 )
        {
            float V3y;
            V3y = V3.y;
            V3 =(transform.forward * Input.GetAxis("Vertical")) + (Input.GetAxis("Horizontal") * transform.right);
            V3 = V3.normalized * speed;
            V3.y = V3y;
            if (contrl.isGrounded)
            {
                V3.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    audio.PlayOneShot(jumpsound, jumpvolume);
                    V3.y = jumpheight;
                }
            }
        } else 
        {
            kbcount -= Time.deltaTime;
        }
    V3.y = V3.y + (Physics.gravity.y * gravityspeed * Time.deltaTime);
    contrl.Move(V3 * Time.deltaTime);

    if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
    {

        transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
        Quaternion newrot = Quaternion.LookRotation(new Vector3 (V3.x, 0f ,V3.z));
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation, newrot, rotspeed + Time.deltaTime);
    }   

    anim.SetBool("Grounded", contrl.isGrounded);
    anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
    public void knockback(Vector3 direction)
    {
        kbcount = kbtime;
        direction = new Vector3(1f, 1f, 1f);
        V3 = direction * kb;
        V3.y = kb;
    }


}

