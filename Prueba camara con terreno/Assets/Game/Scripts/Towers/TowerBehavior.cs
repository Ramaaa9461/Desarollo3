using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    int indexRay = 0;
    int currentRay = 0;

    List<GameObject> rayList;

    private LineRenderer lr;
    BaseTower baseTower;
    Vector3 nextPosition;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        baseTower = transform.parent.GetComponent<BaseTower>();

        rayList = baseTower.GetRayList();
    }

    private void Start()
    {
        for (int i = 0; i < rayList.Count; i++)
        {
            if (rayList[i] == gameObject)
            {
                indexRay = i;
            }
        }

        if (indexRay != rayList.Count - 1)
        {
            currentRay = indexRay + 1;

            rayList[indexRay].transform.LookAt(rayList[currentRay].transform);
        }
        else
        {
            rayList[indexRay].transform.LookAt(rayList[0].transform);
            currentRay = 0;
        }

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, rayList[currentRay].transform.position);
    }


    public void CheckIndexRayDown()
    {
        currentRay--;

        if (currentRay == indexRay)
        {
            currentRay--;
        }

        if (currentRay < 0)
        {
            currentRay = rayList.Count - 1;
        }

        rayList[indexRay].transform.LookAt(rayList[currentRay].transform);

        nextPosition = rayList[currentRay].transform.position;

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, nextPosition);
    }

    public void CheckIndexRayUp()
    {
        currentRay++;

        if (currentRay > rayList.Count - 1)
        {
            currentRay = 0;
        }

        if (currentRay == indexRay)
        {
            currentRay++;
        }

        rayList[indexRay].transform.LookAt(rayList[currentRay].transform);

        nextPosition = rayList[currentRay].transform.position;

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, nextPosition);
    }
}
