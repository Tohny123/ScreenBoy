using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    public Vector3 offset; 

    public float maxangle;
    public float minangle;

    public bool useoffset;

    public float camspeed;

    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
       if (!useoffset){
        offset = target.position - transform.position;
        }
    pivot.transform.position = target.transform.position;
    //pivot.transform.parent = target.transform;
    pivot.transform.parent = null;
    Cursor.lockState = CursorLockMode.Locked;
    }

    // LateUpdate is called once per frame 
    void LateUpdate()
    {

        pivot.transform.position = target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * camspeed;
        pivot.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * camspeed;
        pivot.Rotate(-vertical, 0, 0);

        if (pivot.rotation.eulerAngles.x > maxangle && pivot.rotation.eulerAngles.x < 180f){
            pivot.rotation = Quaternion.Euler(maxangle, pivot.rotation.eulerAngles.y, 0f);
        }
        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minangle){
            pivot.rotation = Quaternion.Euler(360f + minangle, pivot.rotation.eulerAngles.y, 0f);
        }

        float wantedyvalue = pivot.eulerAngles.y;
        float wantedxvalue = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(wantedxvalue, wantedyvalue, 0);
        transform.position = target.position - (rotation * offset);
        if (transform.position.y < target.position.y){
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
        transform.LookAt(target);
    }
}
