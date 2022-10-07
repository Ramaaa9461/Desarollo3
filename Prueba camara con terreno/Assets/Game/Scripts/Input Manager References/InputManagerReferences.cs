using UnityEngine;



public class InputManagerReferences : MonoBehaviour
{
	[Header("Button names")]
	[SerializeField] string changeCamera = "";

	[Header("Axis names")]
	[SerializeField] string horizontalMouse = "";
	[SerializeField] string verticalMouse = "";
	[Space(10)]
	[SerializeField] string horizontalMovement = "";
	[SerializeField] string verticalMovement = "";
	[Space(10)]
	[SerializeField] string cameraZoom = "";


	public string GetChangeCameraName()
	{
		return changeCamera;
	}

	public string GetHorizontalMouseName()
	{
		return horizontalMouse;
	}
	public string GetVerticalMouseName()
	{
		return verticalMouse;
	}

	public string GetHorizontalMovementName()
	{
		return horizontalMovement;
	}
	public string GetVerticalMovementName()
	{
		return verticalMovement;
	}

	public string GetCameraZoom()
	{
		return cameraZoom;
	}
}
