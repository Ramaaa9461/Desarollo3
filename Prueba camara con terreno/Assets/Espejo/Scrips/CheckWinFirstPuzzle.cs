using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckWinFirstPuzzle : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] BaseTower baseTower;
    [SerializeField] LigthButton lightButton;
    bool openDoor = false;

    public void pressButton()
    {
        openDoor = baseTower.checkWinCondition();


        if (Door)
        {
            if (openDoor)
            {
                Door.transform.position += Vector3.left * Time.deltaTime;
                Destroy(Door);
            }
        }

        lightButton.ChangeLigthColor(openDoor);
    }


}
