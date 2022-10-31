using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsController : MonoBehaviour
{
	[SerializeField] string menuSceneName = "";



	public void LoadMenuScene()
	{
		SceneManager.LoadScene(menuSceneName);
	}
}
