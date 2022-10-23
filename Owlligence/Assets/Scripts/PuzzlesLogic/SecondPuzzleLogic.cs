using UnityEngine;

public class SecondPuzzleLogic : ColumnLogicBase
{
    [SerializeField] GameObject secondPuzzleDoor;
    [SerializeField] TreeGrowth treeGrowth;
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
            currentColum.transform.position = pivotsColumns[indexColum].position;
            currentColum.gameObject.layer = 0;
        }

        if (!doorIsOpen)
        {
            if (CheckWincondition())
            {
                secondPuzzleDoor.GetComponent<OpenDoor>().UpTheDoor();
                treeGrowth.UpTree();
                doorIsOpen = true;
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
