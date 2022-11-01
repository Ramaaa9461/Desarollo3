using UnityEngine;


public class CheckFinishGame : MonoBehaviour
{
    [SerializeField] GameObject particles = null;



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (particles != null && particles.activeSelf)
			{
                //cambiar de escena
                Debug.Log("LLEGO");
            }
            else
			{
                Debug.Log("Punto de llegada desactivado.");
            }
        }
    }
}
