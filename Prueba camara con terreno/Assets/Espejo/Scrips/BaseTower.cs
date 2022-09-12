using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] List<GameObject> rayList = new List<GameObject>();
    List<Quaternion> Winrotations = new List<Quaternion>();
    int counter = 0;

    public List<GameObject> GetRayList()
    {
        return rayList;
    }

    private void Awake()
    {
        SetWinCondition();
    }

    public bool checkWinCondition()
    {
        counter = 0;

        for (int i = 0; i < rayList.Count; i++)
        {
            if (rayList[i].transform.rotation == Winrotations[i])
            {
                counter++;
                Debug.Log(counter);
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

    public void SetWinCondition()
    {
        rayList[0].transform.LookAt(rayList[3].transform);
        rayList[1].transform.LookAt(rayList[2].transform);
        rayList[2].transform.LookAt(rayList[0].transform);
        rayList[3].transform.LookAt(rayList[1].transform);

        Winrotations.Add(rayList[0].transform.rotation);
        Winrotations.Add(rayList[1].transform.rotation);
        Winrotations.Add(rayList[2].transform.rotation);
        Winrotations.Add(rayList[3].transform.rotation);


    }
}