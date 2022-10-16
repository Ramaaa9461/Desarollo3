using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentPlayer : MonoBehaviour
{
    Material[] materials;
    [SerializeField] Material transparent;
    [SerializeField] GameObject[] objectsToHide;

    void Start()
    {
        materials = new Material[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            materials[i] = transform.GetChild(i).GetComponent<Renderer>().material;
        }

    }

    public void TransparentColorPlayer()
    {
        for (int i = 0; i < transform.childCount; i++)
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
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Renderer>().material = materials[i];
        }

        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(true);
        }
    }
}
