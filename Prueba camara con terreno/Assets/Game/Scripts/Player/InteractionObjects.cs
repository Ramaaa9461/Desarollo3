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
            if (hit.transform.tag == columnsTag) //serian las columans del segundoNivel
            {
                GrabAndDropColumns(hit, grippablesObjectsParent.transform, columnsTag, grippablesObjectsParent.transform.GetComponent<ColumnLogicBase>().columnsCount);
            }
            else if(hit.transform.tag == tutorialTag) //serian las columans del tutorial
            {
                GrabAndDropColumns(hit, tutorialParent, tutorialTag, 9); //Los objetos totales del padre, esta medio choto
            }
            else if (hit.transform.CompareTag("Button"))  //Si es un boton
            {
                if (Input.GetMouseButton(0))
                {
                    hit.transform.GetComponent<ButtonBase>().pressButton();
                }
            }
        }
    }


    void GrabAndDropColumns(RaycastHit hit, Transform parent, string tagName, int numberColumsInParent)
    {
        if (hit.transform.gameObject.CompareTag(tagName)) // Si intactua con un objeto agarrable
        {
            if (hit.transform.parent == parent.transform)
            {
                if (parent.transform.childCount == numberColumsInParent) //Mejorar numero harcodeado
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Vector3 colliderBounds = hit.collider.bounds.size;

                        hit.transform.rotation = transform.rotation;
                        hit.transform.SetParent(transform);
                        hit.transform.position = transform.position + transform.forward * (colliderBounds.z + offsetGrippeablesObjectsZ) + transform.up * (colliderBounds.y / 2 + offsetGrippeablesObjectsY) + transform.right * transform.localScale.x / 2.0f;
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