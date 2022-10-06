using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiegeticUI : MonoBehaviour
{
    Camera cam;
    [SerializeField] GameObject UiCanvas;
    void Awake()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        //UiCanvas.transform.LookAt(cam.transform);
        UiCanvas.transform.rotation = cam.transform.rotation;
    }

    public void DigeticUiOn()
    {
       // UiCanvas.enabled = true;
        UiCanvas.SetActive( true);
    }
    public void DigeticUiOff()
    {
       // UiCanvas.enabled = false;
        UiCanvas.SetActive(false);
    }

}
