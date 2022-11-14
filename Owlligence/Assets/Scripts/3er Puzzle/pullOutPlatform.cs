using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullOutPlatform : MonoBehaviour
{

    [SerializeField] float duration;
    float distance;
    Coroutine pullOut;
    BoxCollider boxCollider;

    void Awake()
    {
        boxCollider = GetComponentInChildren<BoxCollider>();
        distance = boxCollider.bounds.size.x - 0.2f;
    }

    public void PullPlatformaOutside()
    {
        if (pullOut == null)
        {
            pullOut = StartCoroutine(PullOutPlatform());
        }
    }

    IEnumerator PullOutPlatform()
    {
        float timer = 0;

        Vector3 newPosition = transform.position - transform.right * distance; //new Vector3(transform.position.x, transform.position.y + distanceUp, transform.position.z);


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
