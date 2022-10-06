using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    Camera cam;
    [SerializeField] float speed = 4;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float gravity = Physics.gravity.y;
    [SerializeField] float fallGravity = Physics.gravity.y;
    [SerializeField] float flightGravity = Physics.gravity.y / 2;
    Vector3 movement = Vector3.zero;
    public float verticalSpeed;

    [SerializeField] Transform pivotDown;

    [SerializeField] bool thirdPersonCamera = true;
    [SerializeField] float verticalDownAngle = 0.0f;
    [SerializeField] Transform cameraPosition = null;
    [SerializeField] float sensitivity = 0.0f;
    [SerializeField] CameraFirstPerson cameraScriptFP = null;



    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
        cameraScriptFP = GetComponent<CameraFirstPerson>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            SwitchCameraConfiguration();
        }

        if (thirdPersonCamera)
        {
            UpdateThirdPersonCamera();
        }
    }

    void UpdateThirdPersonCamera()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        movement = Vector3.zero;

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

            movement = direction * speed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
        }

        CheckJump();

        movement.y = verticalSpeed * Time.deltaTime;

        characterController.Move(movement);
    }


    public void CheckJump()
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
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            verticalSpeed = jumpForce;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            movement += transform.forward * 5;  // En esta linea se puede hacer el Dash

            gravity = flightGravity;
        }
    }

    public float GetFallSpeed()
    {
        return verticalSpeed * Time.deltaTime;
    }

    void SwitchCameraConfiguration()
    {
        thirdPersonCamera = !thirdPersonCamera;
        cam.GetComponent<CameraOrbit>().enabled = !cam.GetComponent<CameraOrbit>().enabled;
        cameraScriptFP.enabled = !cameraScriptFP.enabled;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -transform.up, characterController.height / 2 - 0.15f) && verticalSpeed <= 0;
    }

}
