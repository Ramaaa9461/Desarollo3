using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Collider collider;
    float DistanceY;


    void Awake()
    {
        collider = GetComponent<Collider>();

        DistanceY = collider.bounds.size.y - 0.2f;
    }

    public void UpTheDoor()
    {
        StartCoroutine(DoorOpen(DistanceY));
    }

    IEnumerator DoorOpen(float distanceUp)
    {
        float progress = 0;

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + distanceUp, transform.position.z);

        while (progress <= 1)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, progress);
            progress += Time.deltaTime / 4; //De aca se limita la velocidad del Lerp
            yield return null;
        }
        transform.position = newPosition;
    }

}
