using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjects : MonoBehaviour
{
    Transform tutorialParent;
    Transform grippablesObjectsParent;
    [SerializeField] Vector3 offsetGrippeablesObjects;
    [SerializeField] LayerMask InteractableMask;

    string towerTag = "Tower";
    string columnsTag = "Grippable";
    string buttonTag = "Button";
    string tutorialTag = "Tutorial";

    bool useTower = false;
    bool useButton = false;
    bool useColumns = false;

    Collider _collider;
    DiegeticUI diegeticUI;

    private void Awake()
    {
        grippablesObjectsParent = GameObject.Find("Grippables Objects").transform;
        tutorialParent = GameObject.Find("Tutorial").transform;
    }


    void Update()
    {

        if (useTower)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                TowerInteraction(_collider);
            }
        }
        else if (useButton)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ButtonInteraction(_collider);
            }
        }
        else if (useColumns)
        {
            //if (Input.GetMouseButton(0))
            //{
                ColumnsInteraction(_collider);
            //}
        }


    }

    private void OnTriggerEnter(Collider other) //Hacer chequo en Enter
    {
        if (InteractableMask.Contains(other.gameObject.layer)) //Layer interactuable
        {
            if (_collider == null)
            {
                _collider = other;
            }

            diegeticUI = other.gameObject.GetComponent<DiegeticUI>();
            diegeticUI.DigeticUiOn();

            if (other.CompareTag(towerTag))
            {
                useTower = true;
            }
            else if (other.CompareTag(buttonTag))
            {
                useButton = true;
            }
            else if (other.CompareTag(columnsTag) || other.CompareTag(tutorialTag))
            {
                useColumns = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_collider == other)
        {
            _collider = null;
            useTower = false;
            useColumns = false;
            useButton = false;
            diegeticUI.DigeticUiOff();
        }

    }

    void ButtonInteraction(Collider hit)
    {
        hit.transform.GetComponentInChildren<ButtonBase>().pressButton();
    }
    void TowerInteraction(Collider hit)
    {
        TowerBehavior towerBehavior = hit.gameObject.transform.GetComponent<TowerBehavior>();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            towerBehavior.CheckIndexRayDown();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            towerBehavior.CheckIndexRayUp();
        }
    }
    void ColumnsInteraction(Collider hit)
    {
        if (hit.transform.tag == columnsTag) //serian las columans del segundoNivel
        {
            GrabAndDropColumns(hit, grippablesObjectsParent.transform, columnsTag, grippablesObjectsParent.transform.GetComponent<ColumnLogicBase>().columnsCount);
        }
        else if (hit.transform.tag == tutorialTag) //serian las columans del tutorial
        {
            GrabAndDropColumns(hit, tutorialParent, tutorialTag, tutorialParent.transform.GetComponent<ColumnLogicBase>().columnsCount); //Los objetos totales del padre, esta medio choto
        }
    }


    void GrabAndDropColumns(Collider hit, Transform parent, string tagName, int numberColumsInParent)
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (hit.transform.gameObject.CompareTag(tagName)) // Si intactua con un objeto agarrable
            {
                if (hit.transform.parent == parent.transform)
                {
                    if (parent.transform.childCount == numberColumsInParent) //Mejorar numero harcodeado
                    {
                        Vector3 colliderBounds = hit.transform.GetComponent<BoxCollider>().bounds.size;

                        hit.transform.rotation = transform.rotation;
                        hit.transform.SetParent(transform);
                        hit.transform.position = transform.position +
                            transform.forward * (colliderBounds.z + offsetGrippeablesObjects.z) +
                            transform.up * (colliderBounds.y / 2 + offsetGrippeablesObjects.y) +
                            transform.right * offsetGrippeablesObjects.x;//* transform.localScale.x / 2.0f;
                    }
                }
                else if (hit.transform.parent == transform)
                {
                    hit.transform.SetParent(parent.transform);

                    hit.transform.GetComponentInParent<ColumnLogicBase>().CheckColumnInCorrectPivot(hit.transform);
                }
            }

        }

    }

}