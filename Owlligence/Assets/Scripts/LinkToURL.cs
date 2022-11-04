using UnityEngine;

using TMPro;


public class LinkToURL : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI text = null;


	void Start()
	{
		//text.text = "Stilized water: " + Application.OpenURL("https://assetstore.unity.com/packages/vfx/shaders/stylized-water-for-urp-162025");
	}


	public void EnterLink(string link)
	{
		Application.OpenURL(link);
	}
}
