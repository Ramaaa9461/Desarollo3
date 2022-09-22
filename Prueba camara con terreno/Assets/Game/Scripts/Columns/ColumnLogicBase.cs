using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColumnLogicBase : MonoBehaviour
{
    [SerializeField] protected Transform[] columns;
    [SerializeField] protected Transform[] pivotsColumns;
    public int columnsCount;

    public abstract void CheckColumnInCorrectPivot(Transform currentColum);
    public abstract bool CheckWincondition();
}
