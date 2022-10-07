using UnityEngine;


namespace Owlligence
{
    public abstract class ButtonBase : MonoBehaviour
    {
        [SerializeField] protected LigthButton lightButton;
        [SerializeField] protected TowersLogicBase towerBase;
        [SerializeField] protected ColumnLogicBase columBase;
        [SerializeField] protected TreeGrowth treeGrowth;


        protected bool doorIsOpen = false;



        public abstract void pressButton();
    }
}
