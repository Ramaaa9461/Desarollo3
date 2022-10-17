using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentPlayer : MonoBehaviour
{
    Material[] materials;
    [SerializeField] GameObject[] objectsToHide;
    [SerializeField] Material transparent;

    void Start()
    {
        materials = new Material[transform.childCount];

        for (int i = 0; i < transform.childCount - 1; i++) // El -1 es porque el pivot de la camara no tiene Render, TODO: Hacer algo mas prolijo Xd
        {
            materials[i] = transform.GetChild(i).GetComponent<Renderer>().material;
        }

    }

    public void TransparentColorPlayer()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
          transform.GetChild(i).GetComponent<Renderer>().material = transparent;
        }

        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(false);
        }

    }

    public void ReturnToOriginalColor()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            transform.GetChild(i).GetComponent<Renderer>().material = materials[i];
        }

        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(true);
        }
    }
}
