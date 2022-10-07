using System.Collections.Generic;

using UnityEngine;


namespace Owlligence
{
    public class BaseTower : MonoBehaviour
    {
        [SerializeField] List<GameObject> rayList = new List<GameObject>();



        public List<GameObject> GetRayList()
        {
            return rayList;
        }
    }
}
