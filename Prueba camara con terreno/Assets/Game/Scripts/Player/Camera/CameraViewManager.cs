using UnityEngine;



public class CameraViewManager : MonoBehaviour
{
    [SerializeField] CameraFirstPerson cfp = null;
    [SerializeField] CameraOrbit co = null;



    public void SwitchCameraType()
	{
        cfp.enabled = !cfp.enabled;
        co.enabled = !co.enabled;
    }
}
