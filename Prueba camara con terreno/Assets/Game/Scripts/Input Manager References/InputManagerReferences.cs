using UnityEngine;


namespace Owlligence
{
	public class InputManagerReferences : MonoBehaviour
	{
		[Header("Button names")]
		[SerializeField] string directAction = "";
		[SerializeField] string changeCamera = "";
		[Space(10)]
		[SerializeField] string secondaryActionLeft = "";
		[SerializeField] string secondaryActionRight = "";

		[Header("Axis names")]
		[SerializeField] string horizontalMouse = "";
		[SerializeField] string verticalMouse = "";
		[Space(10)]
		[SerializeField] string horizontalMovement = "";
		[SerializeField] string verticalMovement = "";
		[Space(10)]
		[SerializeField] string cameraZoom = "";



		public string DirectAction
		{
			get { return directAction; }
		}
		public string ChangeCamera
		{
			get { return changeCamera; }
		}

		public string SecondaryActionLeft
		{
			get { return secondaryActionLeft; }
		}
		public string SecondaryActionRight
		{
			get { return secondaryActionRight; }
		}


		public string HorizontalMouse
		{
			get { return horizontalMouse; }
		}
		public string VerticalMouse
		{
			get { return verticalMouse; }
		}

		public string HorizontalMovement
		{
			get { return horizontalMovement; }
		}
		public string VerticalMovement
		{
			get { return verticalMovement; }
		}

		public string CameraZoom
		{
			get { return cameraZoom; }
		}
	}
}
