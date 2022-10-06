using UnityEngine;


public class CameraFirstPerson : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InputManagerReferences inputManagerReferences = null;
    [SerializeField] Transform positionToGo = null; // El punto donde va a ir la cámara (el gameObject de la posición).
    [SerializeField] GameObject player = null; // Referencia al jugador para girarlo al rotar la cámara.


    [Header("Speed Configuration")]
    [SerializeField] Vector2 sensitivity = Vector2.zero; // Sensibilidad de la cámara.

    [Header("Angle Configuration")]
    [SerializeField] float verticalDownAngle = 0.0f; // Qué tanto puede mirar hacia abajo (en grados). 80 es ideal.



    void Update()
    {
        RotatoryMotion(); // Para rotar la cámara y el jugador (este último lo rota sobre el eje Y, hacia los costados).
    }



    void RotatoryMotion()
    {
        float rotateHorizontal = Input.GetAxis(inputManagerReferences.GetHorizontalMouseName());
        float rotateVertical = Input.GetAxis(inputManagerReferences.GetVerticalMouseName());


        // Rota al jugador horizontalmente (sobre el eje Y).
        player.transform.Rotate(0.0f, rotateHorizontal * sensitivity.y * Time.deltaTime, 0.0f);

        // Rota la cámara verticalmente.
        Vector3 rotation = transform.localEulerAngles;
        rotation.x = (rotation.x - rotateVertical * sensitivity.x * Time.deltaTime + 360) % 360;

        // Verifica si se pasó de los límites.
        if (rotation.x > verticalDownAngle && rotation.x < 180.0f)
        {
            rotation.x = verticalDownAngle;
        }
        else if (rotation.x < 280.0f && rotation.x > 180.0f)
        {
            rotation.x = 280.0f;
        }

        // Alínea la rotación de la cámara en Y al jugador.
        rotation.y = player.transform.rotation.eulerAngles.y;

        transform.localEulerAngles = rotation; // Ajusta la rotación de la cámara con los valores establecidos.
        transform.position = positionToGo.position; // Lleva la cámara a la posición que debe seguir.
    }
}
