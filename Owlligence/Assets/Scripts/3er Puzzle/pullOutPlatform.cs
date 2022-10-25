using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullOutPlatform : MonoBehaviour
{

    [SerializeField] float duration;
    float distanceY;
    Coroutine doorOpen;

    void Awake()
    {

        distanceY = transform.lossyScale.y - 0.2f;
    }

    public void PullPlatformaOutside()
    {
        if (doorOpen == null)
        {
            doorOpen = StartCoroutine(DoorOpen(distanceY));
        }
    }

    IEnumerator DoorOpen(float distanceUp)
    {
        float timer = 0;

        Vector3 newPosition = transform.position + transform.up * distanceY; //new Vector3(transform.position.x, transform.position.y + distanceUp, transform.position.z);


        while (timer <= duration)
        {
            float interpolationValue = timer / duration;

            transform.position = Vector3.Lerp(transform.position, newPosition, interpolationValue);

            timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.position = newPosition;
        
        //doorOpen = null;
    }
}
