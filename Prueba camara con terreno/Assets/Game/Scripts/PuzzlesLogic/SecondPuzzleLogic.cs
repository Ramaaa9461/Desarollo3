using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPuzzleLogic : ColumnLogicBase
{
    [SerializeField] GameObject secondPuzzleDoor;
    int indexColum;
   
    private void Start()
    {
    columnsCount = 4;
    }
    public override void CheckColumnInCorrectPivot(Transform currentColum)
    {
        for (int i = 0; i < columns.Length; i++)
        {
            if (columns[i] == currentColum)
            {
                indexColum = i;
                break;
            }
        }

        if (Vector3.Distance(currentColum.position, pivotsColumns[indexColum].position) < 4f)
        {
            currentColum.transform.position = pivotsColumns[indexColum].position;
            //currentColum.tag = null; //Tengo que modificar la layer, pero esto hace que no la pueda agarrar mas
        }

        if (CheckWincondition())
        {
            if (secondPuzzleDoor)
            {
                secondPuzzleDoor.GetComponent<OpenDoor>().UpTheDoor();
               }
        }

    }

    public override bool CheckWincondition()
    {
        int count = 0;

        for (int i = 0; i < columns.Length - 1; i++)
        {
            if (columns[i].position == pivotsColumns[i].position)
            {
                count++;

                if (count >= columns.Length - 1)
                {
                    return true;
                }
            }
            else
            {
                break;
            }
        }

        return false;
    }
}
