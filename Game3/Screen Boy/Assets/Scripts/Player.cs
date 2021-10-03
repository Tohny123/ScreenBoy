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
public Vector3 V3;
public GameObject gamemanager;
public GameManager gameman;
public GameObject cam;
void Start()
    {
        //find gameman and character controller
        gamemanager = GameObject.Find("GameManager");
        gameman = gamemanager.GetComponent<GameManager>();
        contrl = GetComponent<CharacterController>();
        cam = GameObject.Find("Main Camera");
        //set vol of jump
        gameman.volnormal();
        jumpvolume = gameman.vol;
    }

void Update()
    { 
        if(kbcount <= 0 )
        {
         //move   
            float V3y;
            V3y = V3.y;
            V3 =(transform.forward * Input.GetAxis("Vertical")) + (Input.GetAxis("Horizontal") * transform.right);
            V3 = V3.normalized * speed;
            V3.y = V3y;
            //ground check
            if (contrl.isGrounded)
            {
                V3.y = 0f;
                //jump
                if (Input.GetButtonDown("Jump"))
                {
                    audio.PlayOneShot(jumpsound, jumpvolume);
                    V3.y = jumpheight;
                }
            }
        } else 
        {
            //reset kbcount
            kbcount -= Time.deltaTime;
        }
    //fall to ground after jump
    V3.y = V3.y + (Physics.gravity.y * gravityspeed * Time.deltaTime);
    contrl.Move(V3 * Time.deltaTime);
    //move horizontal
    if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
    {

        transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
        Quaternion newrot = Quaternion.LookRotation(new Vector3 (V3.x, 0f ,V3.z));
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation, newrot, rotspeed + Time.deltaTime);
    }   
    //animation
    anim.SetBool("Grounded", contrl.isGrounded);
    anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
    //knockback
    public void knockback(Vector3 direction)
    {
        kbcount = kbtime;
        //direction = new Vector3(cam.transform.position.normalized.x, cam.transform.position.y ,cam.transform.position.normalized.z);
        V3 = cam.transform.position.normalized * kb;
    }


}

