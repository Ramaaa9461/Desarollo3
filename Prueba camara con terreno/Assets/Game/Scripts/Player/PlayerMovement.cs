using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gravity Values")]
    [SerializeField] float jumpForce = 15.0f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float fallGravity = -18.0f;
    [SerializeField] float flightGravity = -9.0f;
    [SerializeField] float verticalSpeed = 0.0f;
    [SerializeField] float duration = 0;
    [SerializeField] float _dashVelocity = 0;
    [SerializeField] float rotationSpeed = 0;

    [Header("Speed Values")]
    [SerializeField] float movementSpeed = 20.0f;

    [Header("References")]
    [SerializeField] InputManagerReferences inputManagerReferences = null;
    [SerializeField] Transform[] children = null;
    [SerializeField] CameraViewManager cameraViewManager = null;


    CharacterController characterController;
    Camera cam;
    bool thirdPersonCamera = true;
    bool useDash = true;
    Coroutine startDash;
    Vector3 movement = Vector3.zero;
    Vector3 dashVelocity = Vector3.zero;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    void Start()
    {
        children = gameObject.GetComponentsInChildren<Transform>(true);
    }

    void Update()
    {
        if (Input.GetButtonDown(inputManagerReferences.GetChangeCameraName()))
        {
            SwitchCameraConfiguration();
        }

        if (thirdPersonCamera)
        {
            MovePlayerInThirdPerson();
        }
        else
        {
            MovePlayerInFirstPerson();
        }
    }



    void MovePlayerInThirdPerson()
    {
        float hor = Input.GetAxis(inputManagerReferences.GetHorizontalMovementName());
        float ver = Input.GetAxis(inputManagerReferences.GetVerticalMovementName());


        movement = dashVelocity * Time.deltaTime;

        if (hor != 0 || ver != 0)
        {
            Vector3 forward = cam.transform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = cam.transform.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            direction.Normalize();

            movement += direction * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        }

        CheckJump();

        movement.y = verticalSpeed * Time.deltaTime;
        characterController.Move(movement);
    }
    void MovePlayerInFirstPerson()
    {
        float hor = Input.GetAxis(inputManagerReferences.GetHorizontalMovementName());
        float ver = Input.GetAxis(inputManagerReferences.GetVerticalMovementName());
        Vector3 direction = Vector3.zero;


        CheckJump();

        direction = transform.right * hor + transform.forward * ver + transform.up * verticalSpeed * Time.deltaTime;
        characterController.Move(direction);
    }

    void CheckJump()
    {
        bool isGrounded = IsGrounded();

        if (!isGrounded)
        {
            verticalSpeed += gravity * Time.deltaTime;
        }
        else
        {
            gravity = fallGravity;
            verticalSpeed = 0;
            useDash = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                verticalSpeed = jumpForce;
            }
            else
            {
                if (useDash)
                {
                    if (startDash == null)
                    {
                        StartCoroutine(StartDash(transform));
                    }

                    gravity = flightGravity;
                    useDash = false;
                }
            }
        }
    }

    IEnumerator StartDash(Transform direction)
    {
        float timer = 0;
        float dashVel = _dashVelocity;

        while (timer <= duration)
        {
            float interpolationValue = 1 - timer / duration;

            //dashVelocity = Vector3.Lerp(transform.position, endPosition, interpolationValue);
            dashVelocity = direction.forward * _dashVelocity * interpolationValue;


            timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }



        dashVelocity = Vector3.zero;// = endPosition;
        startDash = null;
    }

    void SwitchCameraConfiguration()
    {
        thirdPersonCamera = !thirdPersonCamera;
        cameraViewManager.SwitchCameraType();

        if (thirdPersonCamera)
        {
            gameObject.layer = 0;

            for (int i = 0; i < children.Length; i++)
            {
                children[i].gameObject.layer = 0;
            }
        }
        else
        {
            gameObject.layer = 7;

            for (int i = 0; i < children.Length; i++)
            {
                children[i].gameObject.layer = 7;
            }
        }
    }

    bool IsGrounded()
    {
        // return Physics.Raycast(transform.position, -transform.up, characterController.height / 2 - 0.15f) && verticalSpeed <= 0;
        Debug.DrawRay(transform.position, -transform.up, Color.blue, characterController.height / 2);

        Vector3 origin = transform.position - transform.up;
        Vector3 direction;
        bool pego = false;

        if (Physics.SphereCast(transform.position, characterController.radius / 2, -transform.up, out var hit, characterController.height / 2))
        {
            Debug.Log(hit.transform.name, hit.transform.gameObject); 
            pego = true;
        }

        return pego;
    }
}



