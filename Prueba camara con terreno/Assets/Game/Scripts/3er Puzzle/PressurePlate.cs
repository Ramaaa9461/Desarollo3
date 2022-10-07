using UnityEngine;


namespace Owlligence
{
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] DirectionMove direction;


        PlateBehavior plateBehavior;
        float counter = 0;
        bool canMove = true;



        void OnTriggerStay(Collider other)
        {
            counter += Time.deltaTime;

            if (counter > 1.0f && canMove)
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

        void OnTriggerExit(Collider other)
        {
            canMove = true;
        }
    }
}
