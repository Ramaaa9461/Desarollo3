using UnityEngine;


namespace Owlligence
{
    public abstract class ColumnLogicBase : MonoBehaviour
    {
        [SerializeField] protected Transform[] columns;
        [SerializeField] protected Transform[] pivotsColumns;


        protected int columnsCount;
        protected bool doorIsOpen = false;
    


        public int ColumnsCount
		{
            get { return columnsCount; }
		}


        public abstract void CheckColumnInCorrectPivot(Transform currentColum);
        public abstract bool CheckWincondition();
    }
}
