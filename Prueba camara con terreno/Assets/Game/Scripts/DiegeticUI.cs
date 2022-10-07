using UnityEngine;


namespace Owlligence
{
    public class DiegeticUI : MonoBehaviour
    {
        [SerializeField] GameObject UiCanvas;


        Camera cam;



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
            UiCanvas.SetActive(true);
        }
        public void DigeticUiOff()
        {
           // UiCanvas.enabled = false;
            UiCanvas.SetActive(false);
        }
    }
}
