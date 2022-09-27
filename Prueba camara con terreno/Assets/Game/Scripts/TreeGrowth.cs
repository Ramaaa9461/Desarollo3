using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth : MonoBehaviour
{
    Vector3 newPosition;
    Quaternion rotation;

    [SerializeField] float distanceUp;
    [SerializeField] float rotateAngle;

    [SerializeField] float duration;

    Coroutine growingUp;
    private void UpTree()
    {

        if (growingUp == null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                newPosition = new Vector3(transform.position.x, transform.position.y + distanceUp, transform.position.z);
                rotation = Quaternion.AngleAxis(rotateAngle, Vector3.up) * transform.rotation;

                growingUp = StartCoroutine(GrowingUp(newPosition, rotation));
            }
        }
    }


    IEnumerator GrowingUp(Vector3 newPosition, Quaternion newRotation)
    {
        float timer = 0;



        while (timer <= duration)
        {
            float interpolationValue = timer / duration;

            transform.position = Vector3.Lerp(transform.position, newPosition, interpolationValue);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, interpolationValue);

            timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.position = newPosition;
        transform.rotation = newRotation;
        growingUp = null;
    }

}
