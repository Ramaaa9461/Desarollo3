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

        for (int i = 0; i < transform.childCount; i++) // El -1 es porque el pivot de la camara no tiene Render, TODO: Hacer algo mas prolijo Xd
        {
            Renderer renderer;
            if (transform.GetChild(i).TryGetComponent<Renderer>(out renderer))
            {
                materials[i] = renderer.material;
            }
        }

    }

    public void TransparentColorPlayer()
    {
        for (int i = 0; i < transform.childCount ; i++)
        {
                Renderer renderer;
            if (transform.GetChild(i).TryGetComponent<Renderer>(out renderer))
            {
                 renderer.material = transparent;
            }
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
            Renderer renderer;
            if (transform.GetChild(i).TryGetComponent<Renderer>(out renderer))
            {
                renderer.material = materials[i];
            }
        }

        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(true);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Entro");
    //    if (other.CompareTag("MainCamera"))
    //    {
    //        TransparentColorPlayer();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("MainCamera"))
    //    {
    //        ReturnToOriginalColor();
    //    }
    //}

}
