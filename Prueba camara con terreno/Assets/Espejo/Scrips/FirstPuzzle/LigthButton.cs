using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthButton : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float duration;

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
        yield return new WaitForSeconds(duration);

        material.color = new Color(0, 0, 0, 0);
    }

}
