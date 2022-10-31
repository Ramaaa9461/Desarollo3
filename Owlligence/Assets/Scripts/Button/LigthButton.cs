using System.Collections;

using UnityEngine;


public class LigthButton : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float duration;

    [SerializeField] AudioSource correctSound = null;
    [SerializeField] AudioSource errorSound = null;



    public void ChangeLigthColor(bool correctPattern)
    {
        if (correctPattern)
        {
            material.color = new Color(0,1,0,1); // Color verde (correcto).
            correctSound.Play();
        }
        else
        {
            material.color = new Color(1,0,0,1); // Color rojo (incorrecto).
            errorSound.Play();
        }

        StartCoroutine(BackToOriginalColor());
    }
  
    IEnumerator BackToOriginalColor()
    {
        yield return new WaitForSeconds(duration);

        material.color = new Color(0, 0, 0, 0);
    }

}
