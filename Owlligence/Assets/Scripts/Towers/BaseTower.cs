using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] List<GameObject> rayList = new List<GameObject>();
    Vector3[] rayInitPosition;

    private void Awake()
    {
        rayInitPosition = new Vector3[rayList.Count];

        for (int i = 0; i < rayList.Count ; i++)
        {
            rayInitPosition[i] = rayList[i].transform.GetChild(0).transform.GetChild(0).position;
        }
    }


    public List<GameObject> GetRayList()
    {
        return rayList;
    }
    public Vector3[] GetRaysInitPositions()
    {
        return rayInitPosition;
    }
}