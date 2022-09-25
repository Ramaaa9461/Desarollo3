
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    struct CameraState
    {
       public Vector3 position;
       public Vector3 rotation;
       public Transform lookAt;
       public float time;
    }
    bool inTransition = false;
    CameraState startState;
    CameraState endState;
    float transitionTime = 0.0f;


    private Vector2 angle = new Vector2(90 * Mathf.Deg2Rad, 0);
    private new Camera camera;
    private Vector2 nearPlaneSize;

    [SerializeField] Transform follow;
    [SerializeField] float maxDistance;
    [SerializeField] Vector2 sensitivity;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponent<Camera>();

        CalculateNearPlaneSize();
    }

    private void CalculateNearPlaneSize()
    {
        float height = Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2) * camera.nearClipPlane;
        float width = height * camera.aspect;

        nearPlaneSize = new Vector2(width, height);
    }

    private Vector3[] GetCameraCollisionPoints(Vector3 direction)
    {
        Vector3 position = follow.position;
        Vector3 center = position + direction * (camera.nearClipPlane + 0.5f); //Originalmente en .2

        Vector3 right = transform.right * nearPlaneSize.x;
        Vector3 up = transform.up * nearPlaneSize.y;

        Debug.DrawLine(center - right + up, center + right + up, Color.blue);
        Debug.DrawLine(center + right + up, center - right - up, Color.blue);
        Debug.DrawLine(center - right - up, center + right - up, Color.blue);
        Debug.DrawLine(center + right - up, center - right + up, Color.blue);


        return new Vector3[]
        {
            center - right + up,
            center + right + up,
            center - right - up,
            center + right - up
        };
    }

    void Update()
    {
        float hor = Input.GetAxis("Mouse X");

        if (hor != 0)
        {
            angle.x += hor * Mathf.Deg2Rad * sensitivity.x * Time.deltaTime; //Agregar DeltaTime
        }

        float ver = Input.GetAxis("Mouse Y");

        if (ver != 0)
        {
            angle.y += ver * Mathf.Deg2Rad * sensitivity.y * Time.deltaTime;
            angle.y = Mathf.Clamp(angle.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);
        }

        Zoom();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = new Vector3(
            Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
            -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)
            );

        RaycastHit hit;
        float distance = maxDistance;
        Vector3[] points = GetCameraCollisionPoints(direction);

        foreach (Vector3 point in points)
        {
            if (Physics.Raycast(point, direction, out hit, maxDistance,LayerMask.GetMask("Map")))
            {
                distance = Mathf.Min((hit.point - follow.position).magnitude, distance);
            }
                Debug.DrawLine(point, transform.position, Color.white);
        }


     //   transform.position = follow.position + direction * distance;
        transform.position = Vector3.Lerp(transform.position, follow.position + direction * distance, .9f);

        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }

    public void TransitionTo(Vector3 finalPosition, Vector3 finalRotation, Transform finalLookAt, float duration)
    {
        startState.position = transform.position;
        startState.rotation = transform.rotation.eulerAngles;
        startState.lookAt = follow;
        startState.time = Time.time;


        endState.position = finalPosition;
        endState.rotation = finalRotation;
        endState.lookAt = finalLookAt;
        endState.time = duration;

        inTransition = true;

    }

    void Zoom()
    {
        //Zoom de la camara segun la rueda del mouse

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && maxDistance > 4f) //4
        {
           maxDistance -= 1f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && maxDistance < 20f) 
        {
            maxDistance += 1f;
        }
    }
}


//  https://www.youtube.com/watch?v=ffs_dI6gzyQ