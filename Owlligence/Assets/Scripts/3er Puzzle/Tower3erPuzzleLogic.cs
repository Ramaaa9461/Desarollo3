using System.Collections.Generic;
using UnityEngine;

public class Tower3erPuzzleLogic : TowersLogicBase
{
    int counter = 0;

    private void Awake()
    {
        rayList = transform.GetComponent<BaseTower>().GetRayList();
        Winrotations = new List<Quaternion>();
        SetWinCondition();
    }

    public override bool CheckWinCondition()
    {
        counter = 0;

        for (int i = 0; i < rayList.Count; i++)
        {
            if (rayList[i].transform.rotation == Winrotations[i])
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
        rayList[1].transform.LookAt(rayList[2].transform);
        rayList[2].transform.LookAt(rayList[3].transform);
        rayList[3].transform.LookAt(rayList[0].transform);

        Winrotations.Add(rayList[0].transform.rotation);
        Winrotations.Add(rayList[1].transform.rotation);
        Winrotations.Add(rayList[2].transform.rotation);
        Winrotations.Add(rayList[3].transform.rotation);
    }
}
