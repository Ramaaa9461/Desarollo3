using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTotemBehaviour : MonoBehaviour
{
    [SerializeField] GameObject fire;


    private void Update()
    {
        if (transform.parent.tag == "Player")
        {
            fire.SetActive(false);
        }
        else
        {
            fire.SetActive(true);
        }


    }


}
