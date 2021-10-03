using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; 
    public Vector3 trueoffset;
    public float maxangle;
    public float minangle;
    public bool useoffset;
    public float camspeed;
    public Transform pivot;
    public GameObject gamemanager;
    public GameManager gameman;

    // Start is called before the first frame update
    void Start()
    {
        //find gameman
        gamemanager = GameObject.Find("GameManager");
        gameman = gamemanager.GetComponent<GameManager>();
        //offset script
       if (!useoffset){
        offset = target.position - transform.position;
        }
        else
        {
            offset = target.position + trueoffset;
        }
    pivot.transform.position = target.transform.position;
    //pivot.transform.parent = target.transform;
    pivot.transform.parent = null;
    
    }

    // LateUpdate is called once per frame 
    //lateupdate is better for cameras
    void LateUpdate()
    {
        //set camspeed to be gameman rotspeed
        camspeed = gameman.rotspd;
        //make the pivot on the target
        pivot.transform.position = target.transform.position;
        //horizontal and vertical floats 
        float horizontal = Input.GetAxis("Mouse X") * camspeed;
        pivot.Rotate(0, horizontal, 0);
//        pivot.Rotate(0, horizontal, 0);


        float vertical = Input.GetAxis("Mouse Y") * camspeed;
        pivot.Rotate(vertical, 0, 0);
 //        pivot.Rotate(-vertical, 0, 0);

        //min and max angles
        if (pivot.rotation.eulerAngles.x > maxangle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxangle, pivot.rotation.eulerAngles.y, 0f);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minangle)
        {
            pivot.rotation = Quaternion.Euler(360f + minangle, pivot.rotation.eulerAngles.y, 0f);
        }
        //apply rotation
        float wantedyvalue = pivot.eulerAngles.y;
        float wantedxvalue = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(wantedxvalue, wantedyvalue, 0);
        transform.position = target.position - (rotation * offset);
        //set transform.position.y to targets.position.y
        if (transform.position.y < target.position.y)
        {
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
        transform.LookAt(target);
    }
}
