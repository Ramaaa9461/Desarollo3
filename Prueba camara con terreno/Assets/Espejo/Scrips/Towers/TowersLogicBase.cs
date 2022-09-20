using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowersLogicBase : MonoBehaviour
{
    protected List<GameObject> rayList;
    protected List<Quaternion> Winrotations;

     public abstract bool CheckWinCondition();
     public abstract void SetWinCondition();


}
