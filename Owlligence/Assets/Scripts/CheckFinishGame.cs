using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFinishGame : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //cambiar de escena
            Debug.Log("LLEGO");
        }
    }


}
