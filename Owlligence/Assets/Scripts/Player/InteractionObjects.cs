using UnityEngine;


public class InteractionObjects : MonoBehaviour
{
    Transform tutorialParent;
    Transform grippablesObjectsParent;
    Transform finalPuzzleParent;

    [SerializeField] Vector3 offsetGrippeablesObjects;
    [SerializeField] LayerMask InteractableMask;

    string tutorialTag = "Tutorial";
    string towerPuzzleTag = "Tower";
    string columPuzzleTag = "Grippable";
    string finalPuzzleTag = "FinalPuzzle";
    string buttonTag = "Button";

    bool useTower = false;
    bool useButton = false;
    bool useColumns = false;

    Collider _collider;
    DiegeticUI diegeticUI;

    CharacterController characterController;
    Vector3 offSetDefault;
    Vector3 offSetOnPick;//= new Vector3(0, .3f, 1f);
    float radiusDefault = 0.5f;
    float radiusOnPick = 1;
    private void Awake()
    {
        grippablesObjectsParent = GameObject.Find("Grippables Objects").transform;
        tutorialParent = GameObject.Find("Tutorial").transform;
        finalPuzzleParent = GameObject.Find(finalPuzzleTag).transform;

        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        offSetDefault = characterController.center;
        offSetOnPick = new Vector3(characterController.center.x, characterController.center.y, 1f);
    }

    void Update()
    {

        if (useTower)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                if (_collider.CompareTag(towerPuzzleTag))
                {
                    TowerInteraction(_collider);
                }
            }
        }
        else if (useButton)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_collider.CompareTag(buttonTag))
                {
                    ButtonInteraction(_collider);
                }
            }
        }
        else if (useColumns)
        {
            if (_collider.CompareTag(columPuzzleTag) || _collider.CompareTag(tutorialTag) || _collider.CompareTag(finalPuzzleTag))
            {
                ColumnsInteraction(_collider);
            }
        }


    }

    private void OnTriggerEnter(Collider other) //Hacer chequo en Enter
    {
        if (InteractableMask.Contains(other.gameObject.layer)) //Layer interactuable
        {

            if (_collider == null)
            {
                _collider = other;
                diegeticUI = other.gameObject.GetComponent<DiegeticUI>();
                diegeticUI.DigeticUiOn();


                if (other.CompareTag(towerPuzzleTag))
                {
                    useTower = true;
                }
                else if (other.CompareTag(buttonTag))
                {
                    useButton = true;
                }
                else if (other.CompareTag(columPuzzleTag) || other.CompareTag(tutorialTag) || other.CompareTag(finalPuzzleTag))
                {
                    useColumns = true;
                }
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
        if (hit.transform.tag == columPuzzleTag) //serian las columans del segundoNivel
        {
            GrabAndDropColumns(hit, grippablesObjectsParent.transform, columPuzzleTag);
        }
        else if (hit.transform.tag == tutorialTag) //serian las columans del tutorial
        {
            GrabAndDropColumns(hit, tutorialParent, tutorialTag); //Los objetos totales del padre, esta medio choto
        }
        else if (hit.transform.tag == finalPuzzleTag) //serian las columans del tutorial
        {
            GrabAndDropColumns(hit, finalPuzzleParent, finalPuzzleTag); //Los objetos totales del padre, esta medio choto
        }
    }


    void GrabAndDropColumns(Collider hit, Transform parent, string tagName)
    {
        int numberColumsInParent = parent.transform.GetComponent<ColumnLogicBase>().columnsCount;

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.CompareTag(tagName)) // Si intactua con un objeto agarrable
            {
                if (hit.transform.parent == parent.transform)
                {
                    if (parent.transform.childCount == numberColumsInParent) //Mejorar numero harcodeado
                    {
                        characterController.radius = radiusOnPick;
                        characterController.center = offSetOnPick;

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

                    characterController.radius = radiusDefault;
                    characterController.center = offSetDefault;


                    hit.transform.GetComponentInParent<ColumnLogicBase>().CheckColumnInCorrectPivot(hit.transform);


                    _collider = null;
                    useColumns = false;
                }
            }

        }

    }

}