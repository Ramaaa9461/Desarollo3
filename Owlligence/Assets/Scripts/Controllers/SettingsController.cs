using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingsController : MonoBehaviour
{
    [SerializeField] string menuSceneName = "";



    public void SaveAndLoadMenuScene()
	{
        // Se guardan los valores de sonido.
        LoadMenuScene();
	}
    public void LoadMenuScene()
	{
        SceneManager.LoadScene(menuSceneName);
	}
}
