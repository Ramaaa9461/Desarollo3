using System.Collections.Generic;

using UnityEngine;


namespace Owlligence
{
    public class TowerTutorialLogic : TowersLogicBase
    {
        int counter;


        void Awake()
        {
            rayList = transform.GetComponent<BaseTower>().GetRayList();
            winRotations = new List<Quaternion>();

            counter = 0;

            SetWinCondition();
        }



        public override bool CheckWinCondition()
        {
            counter = 0;

            for (int i = 0; i < rayList.Count; i++)
            {
                if (rayList[i].transform.rotation == winRotations[i])
                {
                    counter++;

                    if (counter >= rayList.Count)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public override void SetWinCondition()
        {
            rayList[0].transform.LookAt(rayList[1].transform);
            rayList[1].transform.LookAt(rayList[0].transform);
            rayList[2].transform.LookAt(rayList[0].transform);

            winRotations.Add(rayList[0].transform.rotation);
            winRotations.Add(rayList[1].transform.rotation);
            winRotations.Add(rayList[2].transform.rotation);
        }
    }
}
