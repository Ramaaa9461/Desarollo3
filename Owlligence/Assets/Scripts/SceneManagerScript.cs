using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
	AudioSource AS;
    private void Awake()
    {
		AS = transform.GetComponent<AudioSource>();
    }

	public void PlayClickSound()
    {
		AS.PlayOneShot(AS.clip);
    }

    public void LoadScene(string sceneToLoad)
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}
}
