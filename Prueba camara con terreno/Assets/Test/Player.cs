using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody RB;


    Camera cam;
    CameraMovement cameraMovement;
    Vector3 camForward;

    [SerializeField][Range(1.0f, 10.0f)] float walk_Speed;
    [SerializeField][Range(1.0f, 10.0f)] float backwards_Walk_Speed;
    [SerializeField][Range(1.0f, 10.0f)] float strafe_speed;

    [SerializeField][Range(0.1f, 1.5f)] float rotation_speed;

    [SerializeField][Range(2.0f, 10.0f)] float jump_force;
    private bool jump;

    void Awake()
    {
        cameraMovement = GetComponent<CameraMovement>();
        RB = GetComponent<Rigidbody>();
        cam = cameraMovement.getCamera(); 
    }
    
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //  jump = Input.GetButtonDown("Jump");

        if (!jump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jump = true;
            }
        }


        camForward = Vector3.Scale(cam.transform.forward, new Vector3(1, 1, 1)).normalized;
        Vector3 camFlatFwd = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 flatRight = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);

        Vector3 m_CharForward = Vector3.Scale(camFlatFwd, new Vector3(1, 0, 1)).normalized;
        Vector3 m_CharRigth = Vector3.Scale(flatRight, new Vector3(1, 0, 1)).normalized;

        Debug.DrawLine(transform.position, transform.position + camForward * 5f, Color.red);

        float w_speed;
        Vector3 move = Vector3.zero;
        if (cameraMovement.type == CAMERA_TYPE.FREE_LOOK)
        {
            w_speed = walk_Speed;
            move = v * m_CharForward * w_speed + h * m_CharRigth * walk_Speed;
            cam.transform.position += move * Time.deltaTime;
        }
        else if (cameraMovement.type == CAMERA_TYPE.LOCKED)
        {
            w_speed = (v > 0) ? walk_Speed : backwards_Walk_Speed;
            move = v * m_CharForward * w_speed + h * m_CharRigth * strafe_speed;
        }

        transform.position += move * Time.deltaTime;

        if (jump)
        {
            RB.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
            jump = false;
        }
    }
}
