using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjects : MonoBehaviour
{
    Transform grippablesObjectsParent;
    Transform tutorialParent;
    [SerializeField] float offsetGrippeablesObjectsZ;
    [SerializeField] float offsetGrippeablesObjectsY;

    string towerTag = "Tower";
    string columnsTag = "Grippable";
    string butonTag = "Button";
    string tutorialTag = "Tutorial";

    private void Start()
    {
        grippablesObjectsParent = GameObject.Find("Grippables Objects").transform;
        tutorialParent = GameObject.Find("Tutorial").transform;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            InteractionKeyboard();
        }

        if (Input.GetMouseButtonDown(0))
        {
            InteractionMouse();
        }


        #region relleno

        //RaycastHit hit;

        //// if (Physics.SphereCast(transform.position, 5.0f, transform.forward, out hit, 5f, LayerMask.GetMask("Interactable"))) 
        //if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, LayerMask.GetMask("Interactable")))
        //{

        //    Debug.DrawRay(transform.position, transform.forward * 5f, Color.blue);


        //    if (hit.transform.gameObject.CompareTag("Grippable")) // Si intactua con un objeto agarrable
        //    {
        //        if (hit.transform.parent == grippablesObjectsParent.transform)
        //        {

        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                Vector3 colliderBounds = hit.collider.bounds.size;

        //                //hit.transform.position = transform.position + transform.forward + transform.up;
        //                hit.transform.rotation = transform.rotation;
        //                hit.transform.SetParent(transform);
        //                hit.transform.position = transform.position + transform.forward * (colliderBounds.z + offsetGrippeablesObjects.z) + transform.up * (colliderBounds.y + offsetGrippeablesObjects.y);  //Esta funciooandno raro

        //            }
        //        }
        //        else if (hit.transform.parent == transform)
        //        {
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                hit.transform.SetParent(grippablesObjectsParent.transform);

        //                hit.transform.GetComponentInParent<ColumnBehavior>().CheckColumnInCorrectPivot(hit.transform);

        //                //Ponerlo de nuevo en el suelo
        //            }
        //        }

        //    }
        //    else if (hit.transform.parent && hit.transform.parent.CompareTag("Tower")) //Si interactua con una torre
        //    {
        //        TowerBehavior towerBehavior = hit.transform.parent.GetComponent<TowerBehavior>();

        //        if (Input.GetKeyDown(KeyCode.Q))
        //        {
        //            towerBehavior.CheckIndexRayDown();
        //        }

        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            towerBehavior.CheckIndexRayUp();
        //        }
        //    }
        //    else if (hit.transform.CompareTag("Button"))  //Si es un boton
        //    {
        //        if (Input.GetMouseButton(0))
        //        {
        //            hit.transform.GetComponent<CheckWinFirstPuzzle>().pressButton();
        //        }
        //    }
        //}

        #endregion

    }

    void InteractionKeyboard()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, LayerMask.GetMask("Interactable")))
        {
            if (hit.transform.parent && hit.transform.parent.CompareTag(towerTag)) //Si interactua con una torre
            {
                TowerBehavior towerBehavior = hit.transform.parent.GetComponent<TowerBehavior>();

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    towerBehavior.CheckIndexRayDown();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    towerBehavior.CheckIndexRayUp();
                }
            }

        }
    }

    void InteractionMouse()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, LayerMask.GetMask("Interactable")))
        {
            if (hit.transform.tag == columnsTag)
            {
                GrabAndDropColumns(hit, grippablesObjectsParent.transform, columnsTag);
            }
            else if(hit.transform.tag == tutorialTag) //serian las columans del tutorial
            {
                GrabAndDropColumns(hit, tutorialParent, tutorialTag);
            }
            else if (hit.transform.CompareTag("Button"))  //Si es un boton
            {
                if (Input.GetMouseButton(0))
                {
                    hit.transform.GetComponent<Button>().pressButton();
                }
            }
        }
    }


    void GrabAndDropColumns(RaycastHit hit, Transform parent, string tagName)
    {
        if (hit.transform.gameObject.CompareTag(tagName)) // Si intactua con un objeto agarrable
        {
            if (hit.transform.parent == parent.transform)
            {
             //   if (parent.transform.childCount == parent.transform.GetComponent<ColumnLogicBase>().columnsCount) //Mejorar numero harcodeado
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Vector3 colliderBounds = hit.collider.bounds.size;

                        hit.transform.rotation = transform.rotation;
                        hit.transform.SetParent(transform);
                        hit.transform.position = transform.position + transform.forward * (colliderBounds.z + offsetGrippeablesObjectsZ) + transform.up * (colliderBounds.y / 2 + offsetGrippeablesObjectsY);
                    }
                }
            }
            else if (hit.transform.parent == transform)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit.transform.SetParent(parent.transform);

                    hit.transform.GetComponentInParent<ColumnLogicBase>().CheckColumnInCorrectPivot(hit.transform);
                }
            }
        }


    }

}