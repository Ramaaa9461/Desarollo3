using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CAMERA_TYPE { FREE_LOOK, LOCKED }

public class CameraMovement : MonoBehaviour
{
    public CAMERA_TYPE type = CAMERA_TYPE.FREE_LOOK;
    [SerializeField] Camera cam;

    [Range(0.1f, 2f)]
    [SerializeField] float sensitivity;
    [SerializeField] bool invertXAxis;
    [SerializeField] bool invertYAxis;

    [SerializeField] Transform lookAt;

    void Awake()
    {
        if (type == CAMERA_TYPE.LOCKED)
        {
            cam.transform.parent = transform;
        }
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        h = (invertXAxis) ? (-h) : h;
        v = (invertYAxis) ? (-v) : v;

        if (h != 0)
        {
            if (type == CAMERA_TYPE.LOCKED)
            {
                transform.Rotate(Vector3.up, h * 90 * sensitivity * Time.deltaTime);
            }
            else if (type == CAMERA_TYPE.FREE_LOOK)
            {
                cam.transform.RotateAround(transform.position, transform.up, h * 90 * sensitivity * Time.deltaTime);
            }
        }

        if (v != 0)
        {
            cam.transform.RotateAround(transform.position, transform.right, v * 90 * sensitivity * Time.deltaTime);
        }

        cam.transform.LookAt(lookAt);

        Vector3 ea = cam.transform.rotation.eulerAngles;
        cam.transform.rotation = Quaternion.Euler(new Vector3(ea.x, ea.y, 0.0f));
    }

    public Camera getCamera()
    {
        return cam;
    }
}
