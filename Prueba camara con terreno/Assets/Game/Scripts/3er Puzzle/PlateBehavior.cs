using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{
    [SerializeField] GameObject plate;
    [SerializeField] Transform[] possiblePositions = new Transform[3];
    [SerializeField] float duration;


    int currentPlatform = 0;
    Coroutine movePlate;

    private void Start()
    {
        plate.transform.position = possiblePositions[Random.Range(0, 3)].position;

        for (int i = 0; i < possiblePositions.Length; i++)
        {
            if (plate.transform.position == possiblePositions[i].position)
            {
                currentPlatform = i;
            }
        }
    }

    public void MoveLeft()
    {
        if (currentPlatform != 0)
        {
            currentPlatform--;

            if (movePlate == null)
            {
                StartCoroutine(MovePlate(plate.transform, possiblePositions[currentPlatform].position));
            }
        }
    }
    public void MoveRight()
    {
        if (currentPlatform != possiblePositions.Length - 1)
        {
            currentPlatform++;

            if (movePlate == null)
            {
                StartCoroutine(MovePlate(plate.transform, possiblePositions[currentPlatform].position));
            }

        }
    }
    IEnumerator MovePlate(Transform plate, Vector3 endPosition)
    {
        float timer = 0;



        while (timer <= duration)
        {
            float interpolationValue = timer / duration;

            plate.position = Vector3.Lerp(plate.position, endPosition, interpolationValue);

            timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        plate.position = endPosition;
        movePlate = null;
    }



}

