using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuController : MonoBehaviour
{
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    [SerializeField] GameObject pauseMenuUI = null;

	bool inPause;



	void Awake()
	{
        inPause = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
		{
            if (inPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }



    public void PauseGame()
	{
        inPause = true;
        Time.timeScale = 0.0f;
        pauseMenuUI.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
	}
    public void ResumeGame()
	{
        inPause = false;
        Time.timeScale = 1.0f;
        pauseMenuUI.SetActive(false);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    public void ReturnToMainMenu(string mainMenuSceneName)
	{
        SceneManager.LoadScene(mainMenuSceneName);
	}
}
