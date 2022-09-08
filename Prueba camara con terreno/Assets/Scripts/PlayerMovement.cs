using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    Transform cam;
    [SerializeField] float speed = 4;
    float gravity = Physics.gravity.y;
    public float verticalSpeed;
    [SerializeField] float jumpForce = 10;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;

        if (hor != 0 || ver != 0)
        {
            Vector3 forward = cam.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = cam.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            direction.Normalize();

            movement = direction * speed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
        }

        if (characterController.isGrounded)
        {
            verticalSpeed = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            verticalSpeed = jumpForce;
        }

        verticalSpeed += gravity * Time.deltaTime;


        movement.y = verticalSpeed * Time.deltaTime;

        characterController.Move(movement);
    }
}
