using UnityEngine;

public abstract class ColumnLogicBase : MonoBehaviour
{
    [SerializeField] protected Transform[] columns;
    [SerializeField] protected Transform[] pivotsColumns;
    protected bool doorIsOpen = false;
    
    public int columnsCount;

    public abstract void CheckColumnInCorrectPivot(Transform currentColum);

    public abstract bool CheckWincondition();

}
