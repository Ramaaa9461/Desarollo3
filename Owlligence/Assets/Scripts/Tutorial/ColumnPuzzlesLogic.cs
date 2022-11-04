using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColumnPuzzlesLogic : ColumnLogicBase
{
    public UnityEvent theDoorIsOpen;
    int indexColum;

    private void Start()
    {
        columnsCount = gameObject.transform.childCount;
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
            Destroy(currentColum.GetComponent<Rigidbody>()); // Para que la columna no detecte colisi�n con la
                                                             // base y por ende, no se salga de su lugar al
                                                             // traspasarla.

            currentColum.transform.position = pivotsColumns[indexColum].position;
            currentColum.gameObject.layer = 0;
        }

        if (CheckWincondition())
        {
            theDoorIsOpen.Invoke();
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
