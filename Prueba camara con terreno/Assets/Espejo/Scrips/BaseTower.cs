using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected List<GameObject> rayList = new List<GameObject>();

    public List<GameObject> GetRayList()
    {
        return rayList;
    }

}