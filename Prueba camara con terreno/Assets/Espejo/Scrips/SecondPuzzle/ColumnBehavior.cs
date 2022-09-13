using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehavior : MonoBehaviour
{
    [SerializeField] Transform[] columns = new Transform[4];
    [SerializeField] Transform[] pivotsColumns = new Transform[4];

    int indexColum;

    public void CheckColumnInCorrectPivot(Transform currentColum)
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
            //   currentColum.tag = null; //Tengo que modificar la layer, pero esto hace que no la pueda agarrar mas
        }



    }

    public bool CheckWincondition()
    {
        int count = 0;

        for (int i = 0; i < columns.Length; i++)
        {
            if (columns[i] == pivotsColumns[i])
            {
                count++;

                Debug.Log(count);

                if (count >= columns.Length - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }


}
