using UnityEngine;


public class CameraFirstPerson : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InputManagerReferences inputManagerReferences = null;
    [SerializeField] Transform positionToGo = null; // El punto donde va a ir la c�mara (el gameObject de la posici�n).
    [SerializeField] GameObject player = null; // Referencia al jugador para girarlo al rotar la c�mara.


    [Header("Speed Configuration")]
    [SerializeField] Vector2 sensitivity = Vector2.zero; // Sensibilidad de la c�mara.

    [Header("Angle Configuration")]
    [SerializeField] float verticalDownAngle = 0.0f; // Qu� tanto puede mirar hacia abajo (en grados). 80 es ideal.



    void Update()
    {
        RotatoryMotion(); // Para rotar la c�mara y el jugador (este �ltimo lo rota sobre el eje Y, hacia los costados).
    }



    void RotatoryMotion()
    {
        float rotateHorizontal = Input.GetAxis(inputManagerReferences.GetHorizontalMouseName());
        float rotateVertical = Input.GetAxis(inputManagerReferences.GetVerticalMouseName());


        // Rota al jugador horizontalmente (sobre el eje Y).
        player.transform.Rotate(0.0f, rotateHorizontal * sensitivity.y * Time.deltaTime, 0.0f);

        // Rota la c�mara verticalmente.
        Vector3 rotation = transform.localEulerAngles;
        rotation.x = (rotation.x - rotateVertical * sensitivity.x * Time.deltaTime + 360) % 360;

        // Verifica si se pas� de los l�mites.
        if (rotation.x > verticalDownAngle && rotation.x < 180.0f)
        {
            rotation.x = verticalDownAngle;
        }
        else if (rotation.x < 280.0f && rotation.x > 180.0f)
        {
            rotation.x = 280.0f;
        }

        // Al�nea la rotaci�n de la c�mara en Y al jugador.
        rotation.y = player.transform.rotation.eulerAngles.y;

        transform.localEulerAngles = rotation; // Ajusta la rotaci�n de la c�mara con los valores establecidos.
        transform.position = positionToGo.position; // Lleva la c�mara a la posici�n que debe seguir.
    }
}
