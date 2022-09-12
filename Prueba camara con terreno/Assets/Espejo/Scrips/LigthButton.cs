using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthButton : MonoBehaviour
{
    [SerializeField] Material material;

    public void ChangeLigthColor(bool correctPattern)
    {

        if (correctPattern)
        {
            material.color = new Color(0,1,0,1);
        }
        else
        {
            material.color = new Color(1,0,0,1);
        }

        StartCoroutine(BackToOriginalColor());

    }
  
    IEnumerator BackToOriginalColor()
    {
        yield return new WaitForSeconds(1.5f);

        material.color = new Color(0, 0, 0, 0);
    }

}
