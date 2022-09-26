using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] DirectionMove direction;
    enum DirectionMove { Left, Right }

    float counter = 0;
    PlateBehavior plateBehavior;
    bool canMove = true;


    private void OnTriggerStay(Collider other)
    {

        counter += Time.deltaTime;

        if (counter > 1f && canMove)
        {
            plateBehavior = GetComponentInParent<PlateBehavior>();

            if (direction == DirectionMove.Left)
            {
                plateBehavior.MoveLeft();

            }
            else if (direction == DirectionMove.Right)
            {
                plateBehavior.MoveRight();
            }

            canMove = false;
            counter = 0;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        canMove = true;
    }

}
