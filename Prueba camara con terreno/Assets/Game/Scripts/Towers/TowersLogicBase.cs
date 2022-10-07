using System.Collections.Generic;

using UnityEngine;


namespace Owlligence
{
    public abstract class TowersLogicBase : MonoBehaviour
    {
        protected List<GameObject> rayList;
        protected List<Quaternion> winRotations;



        public abstract bool CheckWinCondition();
        public abstract void SetWinCondition();
    }
}
