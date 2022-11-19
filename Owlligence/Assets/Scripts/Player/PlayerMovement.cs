using UnityEngine;
using System.Collections;
using UnityEngine.UI;


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
    [SerializeField] float sphereCastOffSetY = 0;

    [Header("Speed Values")]
    float currentSpeed = 0.0f;
    [SerializeField] float velocity = 3.0f;
    [SerializeField] float maxSpeed = 15.0f;


    [Header("References")]
    [SerializeField] InputManagerReferences inputManagerReferences = null;
    [SerializeField] Transform[] children = null;
    [SerializeField] CameraViewManager cameraViewManager = null;
    [SerializeField] Transform characterBase;
    [SerializeField] AudioSource jumpSound = null;
    [SerializeField] AudioSource dashSound = null;

    CharacterController characterController;
    Camera cam;
    bool thirdPersonCamera = true;
    bool useDash = true;
    Coroutine startDash;
    Vector3 movement = Vector3.zero;
    Vector3 dashMovement = Vector3.zero;

    //Animation Variables
    Animator animatorController;
    [SerializeField] LayerMask mapLayer;

    //Variables para modo Debug
    [SerializeField] Toggle debugModeUI;
    public bool debugMode = false;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
        animatorController = GetComponentInChildren<Animator>();

        debugModeUI.isOn = debugMode;
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            debugMode = !debugMode;
            debugModeUI.isOn = debugMode;
        }
    }



    void MovePlayerInThirdPerson()
    {
        float hor = Input.GetAxis(inputManagerReferences.GetHorizontalMovementName());
        float ver = Input.GetAxis(inputManagerReferences.GetVerticalMovementName());

        movement = dashMovement * Time.deltaTime;

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

             currentSpeed = currentSpeed < maxSpeed ? currentSpeed += velocity : currentSpeed = maxSpeed;

            if (debugMode)
            {
                currentSpeed = 25;
            }
           
            animatorController.SetFloat("PlayerHorizontalVelocity", currentSpeed);

            movement += direction * currentSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        }
        else
        {
            Vector3 forward = cam.transform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = cam.transform.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            direction.Normalize();

            currentSpeed = currentSpeed <= 0 ? currentSpeed = 0 : currentSpeed -= velocity * 1.5f; //Lo multiplico para que coincida con la animacion

            animatorController.SetFloat("PlayerHorizontalVelocity", currentSpeed);

            movement += direction * currentSpeed * Time.deltaTime; 
        }

        CheckJump();

        movement.y = verticalSpeed * Time.deltaTime;
        characterController.Move(movement);

        calculateDistanceToFloor();
    }
    void MovePlayerInFirstPerson()
    {
        float hor = Input.GetAxis(inputManagerReferences.GetHorizontalMovementName());
        float ver = Input.GetAxis(inputManagerReferences.GetVerticalMovementName());
        Vector3 direction = Vector3.zero;


        CheckJump();

        direction = transform.right * hor * currentSpeed * Time.deltaTime + transform.forward * ver * currentSpeed * Time.deltaTime + transform.up * verticalSpeed * Time.deltaTime;
        characterController.Move(direction);
    }

    void CheckJump()
    {
        bool isGrounded = IsGrounded();
        //  bool isGrounded = characterController.isGrounded;

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
                animatorController.SetTrigger("Jumped");
                jumpSound.Play();
            }
            else if (useDash && startDash == null)
            {
                AnimatorStateInfo stateInfo = animatorController.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.IsName("Base Layer.Jumped") || stateInfo.IsName("Base Layer.Falled") &&
                    animatorController.GetFloat("DistanceToFloor") > 0.04f)
                {
                    animatorController.SetTrigger("Dashed");
                    startDash = StartCoroutine(StartDash());
                    verticalSpeed = 0;
                    dashSound.Play();

                    gravity = flightGravity;
                    useDash = false;
                }
            }
        }

        animatorController.SetBool("IsGrounded", isGrounded);

        if (debugMode)
        {
            if (Input.GetKey(KeyCode.M))
            {
                verticalSpeed += 80 * Time.deltaTime;
            }
        }
    }

    IEnumerator StartDash()
    {
        float timer = 0;

        while (timer <= duration)
        {
            float interpolationValue = 1 - timer / duration;

            //dashVelocity = Vector3.Lerp(transform.position, endPosition, interpolationValue);
            dashMovement = transform.forward * _dashVelocity * interpolationValue;


            timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        dashMovement = Vector3.zero;// = endPosition;
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

    void calculateDistanceToFloor()
    {
        RaycastHit hit;

        if (Physics.Raycast(characterBase.position + Vector3.up / 10, -Vector3.up, out hit, 150.0f))
        {
            float distanceToFloor = 0;
            distanceToFloor = Vector3.Distance(characterBase.position, hit.point);

            animatorController.SetFloat("DistanceToFloor", distanceToFloor / 100);
        }
    }

    bool IsGrounded()
    {
        Vector3 origin = transform.position - new Vector3(0, sphereCastOffSetY, 0);
        RaycastHit hit;
        int divisions = 10;
        Vector3 offSet;

        if (Physics.Raycast(characterBase.position + Vector3.up, Vector3.down, out hit, 1.1f, mapLayer))
        {
            return true;
        }
        else
        {
            float angle = (2 * Mathf.PI) / divisions;
            float x, z;

            for (int i = 0; i < divisions; i++)
            {
                x = Mathf.Cos(angle * i);
                z = Mathf.Sin(angle * i);



                offSet = new Vector3(x / 3f, 0.0f, z / 3f); //Lo divido para achicar el cirulo
                if (Physics.Raycast(characterBase.position + offSet + Vector3.up, Vector3.down, out hit,
                    1.1f, mapLayer))
                {
                    return true;
                }
            }
        }

        return false;
    }
}



//        Debug.DrawRay(characterBase.position, Vector3.down / 10, Color.red, 100);
//Coseno X
//seno Y

