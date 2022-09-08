using UnityEngine;

public class PlayerMovementf : MonoBehaviour
{

    Transform cam;
    Rigidbody RB;

    [SerializeField] float speed = 4;
    [SerializeField] float jumpForce = 10;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;

       // if (hor != 0 || ver != 0)
        //{
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
        //}

        if (Input.GetKeyDown(KeyCode.Space) && RB.velocity.y == 0)
        {
            RB.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
        }

        RB.AddForce(movement);
    }
}
