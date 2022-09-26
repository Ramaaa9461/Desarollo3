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
                Debug.Log(currentPlatform);
            }
        }
    }

    public void MoveLeft()
    {
        if (currentPlatform != 0)
        {
            currentPlatform--;
            plate.transform.position = possiblePositions[currentPlatform].position;
        }
    }
    public void MoveRight()
    {
        if (currentPlatform != possiblePositions.Length - 1)
        {
            currentPlatform++;
            plate.transform.position = possiblePositions[currentPlatform].position;
        }
    }

}
