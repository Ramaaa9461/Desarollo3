using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Vector3 offSet;
    [SerializeField][Range(0,1)] float lerpvalue = 0;
    Transform target;
    private float sensitivity;

    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }


    void LateUpdate()
    {
 
        transform.position = Vector3.Lerp(transform.position, target.position + offSet, lerpvalue);
         offSet = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitivity, Vector3.up) * offSet;
        transform.LookAt(target);
    }
}
