using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    protected int indexRay = 0;
    protected int currentRay = 0;

    List<GameObject> rayList;

    private LineRenderer lr;
public    bool canShootRay = false;
    BaseTower baseTower;
    Vector3 nextPosition;


    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        baseTower = transform.parent.GetComponent<BaseTower>();

        rayList = baseTower.GetRayList();

        lr.enabled = canShootRay;
    }

    private void Start()
    {
        if (indexRay == 0)
        {
            canShootRay = true;
        }

        for (int i = 0; i < rayList.Count; i++)
        {
            if (rayList[i] == gameObject)
            {
                indexRay = i;
            }
        }

        if (indexRay != rayList.Count - 1)
        {
            rayList[indexRay].transform.LookAt(rayList[indexRay + 1].transform);
            currentRay = indexRay + 1;
        }
        else
        {
            rayList[indexRay].transform.LookAt(rayList[0].transform);
            currentRay = 0;
        }
    }

    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    CheckIndexRayDown();
        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    CheckIndexRayUp();
        //}

        lr.enabled = canShootRay;

        if (canShootRay)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, nextPosition);
        }
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
    }

}
