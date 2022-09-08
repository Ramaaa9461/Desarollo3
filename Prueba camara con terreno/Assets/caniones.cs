using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caniones : MonoBehaviour
{
    [SerializeField] List<GameObject> rayo = new List<GameObject>();


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rayo[1].transform.LookAt(rayo[2].transform);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            rayo[1].transform.LookAt(rayo[0].transform);

        }


    }
}
