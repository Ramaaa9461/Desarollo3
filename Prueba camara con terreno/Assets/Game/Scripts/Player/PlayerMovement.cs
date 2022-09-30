using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    Camera cam;
    [SerializeField] float speed = 4;
    float gravity = Physics.gravity.y;
    public float verticalSpeed;
    [SerializeField] float jumpForce = 10;
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


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -transform.up, characterController.height / 2 + .2f) && verticalSpeed <= 0;
    }

    void UpdateThirdPersonCamera()
	{
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;

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
            verticalSpeed = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            verticalSpeed = jumpForce;
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
}
