using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckFinishGame : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] string finalSceneName = "";

    [Header("References")]
    [SerializeField] GameObject particles = null;



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (particles != null && particles.activeSelf)
			{
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(finalSceneName);
            }
            else
			{
                Debug.Log("Punto de llegada desactivado.");
            }
        }
    }
}
