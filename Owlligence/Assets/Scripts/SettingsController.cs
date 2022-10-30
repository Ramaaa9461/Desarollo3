using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingsController : MonoBehaviour
{
    [SerializeField] string menuSceneName = "";



    public void LoadMenuScene()
	{
        SceneManager.LoadScene(menuSceneName);
	}
}
