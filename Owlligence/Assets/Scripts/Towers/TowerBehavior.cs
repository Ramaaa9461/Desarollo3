using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    int indexRay = 0;
    int currentRay = 0;

    List<GameObject> rayList;
    Vector3[] rayInitPosition;

    private LineRenderer lr;
    BaseTower baseTower;

    Coroutine rotateTower;
    [SerializeField] private float duration = 1;
    [SerializeField] LayerMask layerMask;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        baseTower = transform.parent.GetComponent<BaseTower>();

        rayList = baseTower.GetRayList();

    }

    private void Start()
    {
        rayInitPosition = baseTower.GetRaysInitPositions();

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

        lr.SetPosition(0, rayInitPosition[indexRay]);
        lr.SetPosition(1, rayInitPosition[currentRay]);
    }

    public void CheckIndexRayDown()
    {
        if (rotateTower == null)
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
            if (currentRay == indexRay)
            {
                currentRay--;
            }

            //rayList[indexRay].transform.LookAt(rayList[currentRay].transform);
            TowerRotate();
        }
    }

    public void CheckIndexRayUp()
    {
        if (rotateTower == null)
        {
            currentRay++;

            if (currentRay == indexRay)
            {
                currentRay++;
            }

            if (currentRay > rayList.Count - 1)
            {
                currentRay = 0;
            }

            if (currentRay == indexRay)
            {
                currentRay++;
            }

            //  rayList[indexRay].transform.LookAt(rayList[currentRay].transform);
            TowerRotate();
        }
    }

    void TowerRotate()
    {
        Vector3 direction = rayList[currentRay].transform.position - rayList[indexRay].transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        rotateTower = StartCoroutine(RotateTower(rotation));
    }

    IEnumerator RotateTower(Quaternion newRotation)
    {
        float timer = 0;
        Quaternion initialRotation = rayList[indexRay].transform.rotation;

        lr.SetPosition(0, rayInitPosition[indexRay]);

        while (timer <= duration)
        {
            float interpolationValue = timer / duration;

            rayList[indexRay].transform.rotation =
                Quaternion.Lerp(initialRotation, newRotation, interpolationValue);

            RaycastHit hit;
            if (Physics.Raycast(rayInitPosition[indexRay], transform.forward, out hit, 150.0f, layerMask))
            {
                lr.SetPosition(1, hit.point);
            }
            timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        rayList[indexRay].transform.rotation = newRotation;
        lr.SetPosition(1, rayInitPosition[currentRay]);


        rotateTower = null;
    }

    private void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(rayInitPosition[indexRay], transform.forward, out hit, 50.0f, layerMask, QueryTriggerInteraction.Ignore))
        {
            lr.SetPosition(1, hit.point);
        }
    }
}
