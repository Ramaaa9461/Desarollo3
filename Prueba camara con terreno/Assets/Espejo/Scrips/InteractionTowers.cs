using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTowers : MonoBehaviour
{

    void Update()
    {
        RaycastHit hit;

        //   if (Physics.SphereCast(transform.position, 5.0f, transform.forward, out hit, 5f))
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, LayerMask.GetMask("Interactable")))
        {
            Debug.DrawRay(transform.position, transform.forward * 5f, Color.blue);


            if (hit.transform.gameObject.CompareTag("Grippable")) // Si intactua con un objeto agarrable
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit.transform.position = transform.position + transform.forward + transform.up;
                    hit.transform.rotation = transform.rotation;
                    hit.transform.SetParent(transform);
                    Debug.Log("Pressed primary button.");
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("solot primary button.");
                    hit.transform.SetParent(GameObject.Find("Grippables Objects").transform);
                    //Ponerlo de nuevo en el suelo
                }
            }
            else if (hit.transform.parent && hit.transform.parent.CompareTag("Tower")) //Si interactua con una torre
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hit.transform.parent.GetComponent<TowerBehavior>().CheckIndexRayDown();

                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.parent.GetComponent<TowerBehavior>().CheckIndexRayUp();
                }
            }
            else if (hit.transform.CompareTag("Button"))  //Si es un boton
            {
                if (Input.GetMouseButton(0))
                {
                    hit.transform.GetComponent<CheckWinFirstPuzzle>().pressButton();
                }
            }



        }

    }
}
