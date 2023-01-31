using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    public Transform target;
    void Update () {
        transform.position = new Vector3(target.position.x,
                                        transform.position.y,
                                        transform.position.z);
    }

    void LateUpdate () {
    if(target == null) return;
    transform.position = new Vector3(target.position.x,
                                     transform.position.y,
                                     transform.position.z);
    }


    
}
