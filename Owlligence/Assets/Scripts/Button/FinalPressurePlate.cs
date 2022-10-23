using System.Collections;
using UnityEngine;

public class FinalPressurePlate : MonoBehaviour
{
    [SerializeField] protected ColumnLogicBase columBase;
    [SerializeField] GameObject platform;
    bool pullOutPlatform;
    bool platformInside = true;


    float counter = 0;
    bool canPress = true;


    private void OnTriggerStay(Collider other)
    {
        if (platformInside)
        {
            counter += Time.deltaTime;

            if (counter > 1f && canPress)
            {
                pullOutPlatform = columBase.CheckWincondition();

                if (pullOutPlatform)
                {
                    platform.transform.GetComponent<pullOutPlatform>().PullPlatformaOutside();

                    platformInside = false;
                }

                canPress = false;
                counter = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canPress = true;
    }
}
