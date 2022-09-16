
using UnityEngine;

public class CameraOrbital : MonoBehaviour
{
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
            if (Physics.Raycast(point, direction, out hit, maxDistance))
            {
                distance = Mathf.Min((hit.point - follow.position).magnitude, distance);
            }
                Debug.DrawLine(point, transform.position, Color.white);
        }


     //   transform.position = follow.position + direction * distance;
        transform.position = Vector3.Lerp(transform.position, follow.position + direction * distance, .9f);

        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }

}


//  https://www.youtube.com/watch?v=ffs_dI6gzyQ