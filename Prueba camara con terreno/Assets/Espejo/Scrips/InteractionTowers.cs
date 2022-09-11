using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTowers : MonoBehaviour
{

    void Update()
    {
        RaycastHit hit;
        //  if (Physics.SphereCast(transform.position, 2.0f, transform.forward, out hit, 8f))
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {
            if (hit.transform.parent.CompareTag("Tower"))
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hit.transform.parent.GetComponent<TowerBehavior>().CheckIndexRayDown();
                    hit.transform.parent.GetComponent<TowerBehavior>().canShootRay = true;

                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.parent.GetComponent<TowerBehavior>().CheckIndexRayUp();
                    hit.transform.parent.GetComponent<TowerBehavior>().canShootRay = true;
                }
            }

        }

    }
}
