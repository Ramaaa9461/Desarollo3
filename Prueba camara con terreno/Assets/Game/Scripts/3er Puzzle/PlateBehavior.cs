using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{
    [SerializeField] GameObject plate;
    [SerializeField] Transform[] possiblePositions = new Transform[3];

    int currentPlatform = 0;

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
            // plate.transform.position = possiblePositions[currentPlatform].position;

            StartCoroutine(MovePlate(plate.transform, possiblePositions[currentPlatform].position));
        
        }
    }
    public void MoveRight()
    {
        if (currentPlatform != possiblePositions.Length - 1)
        {
            currentPlatform++;
//            plate.transform.position = possiblePositions[currentPlatform].position;
            StartCoroutine(MovePlate(plate.transform, possiblePositions[currentPlatform].position));

        }
    }


    IEnumerator MovePlate(Transform plate, Vector3 endPosition)
    {
        float progress = 0;

        while (progress <= 1)
        {
            plate.transform.position = Vector3.Lerp(plate.transform.position, endPosition, progress);
            progress += Time.deltaTime / 3; //De aca se limita la velocidad del Lerp
            yield return null;
        }
        plate.transform.position = endPosition;
    }
}

