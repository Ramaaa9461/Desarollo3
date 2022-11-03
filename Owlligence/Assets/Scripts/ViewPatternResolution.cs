using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPatternResolution : MonoBehaviour
{
    [SerializeField] GameObject patternResolution;

    float counter = 0;
    bool canPress = true;


    private void OnTriggerStay(Collider other)
    {
        counter += Time.deltaTime;

        if (counter > 1f && canPress)
        {
            patternResolution.SetActive(true);

            canPress = false;
            counter = 0;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        patternResolution.SetActive(false);
        canPress = true;
    }
}
