using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFirstPerson : MonoBehaviour
{
    [Header("Button Names")]
    [SerializeField] string mouseXAxisName = ""; // Hago esto para no tener que modificar el c�digo si en alg�n momento
    [SerializeField] string mouseYAxisName = ""; // se nos ocurre cambiarle el nombre desde el Input Manager.

    [Header("References")]
    [SerializeField] Camera camera = null; // Literalmente la c�mara.
    [SerializeField] Transform positionToGo = null; // El punto donde va a ir la c�mara (el gameObject de la posici�n).
    [SerializeField] CharacterController controllerToMove = null; // El controlador del jugador.
    [SerializeField] PlayerMovement playerToCheckJump = null; // El c�digo de movimiento del jugador, para poder
                                                              // saltar en 1ra persona.
                                                              // Tranquilamente podr�a hacer un GetComponent en el Awake,
                                                              // pero me pareci� m�s claro hacerlo de esta forma.

    [Header("Speed Configuration")]
    [SerializeField] float sensitivity = 0.0f; // Sensibilidad de la c�mara. Deber�a ser la misma que el movimiento de
                                               // giro del jugador.

    [Header("Angle Configuration")]
    [SerializeField] float verticalDownAngle = 0.0f; // Qu� tanto puede mirar hacia abajo (en grados). 80 es ideal.



    void Update()
    {
        playerToCheckJump.CheckJump(); // Sirve tambi�n para actualizar la gravedad.
        RotatoryMotion(); // Para rotar la c�mara y el jugador (este �ltimo lo rota sobre el eje Y, hacia los costados).
    }



    void RotatoryMotion()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float forwardMovement = Input.GetAxis("Vertical");
        float rotateHorizontal = Input.GetAxis(mouseXAxisName);
        float rotateVertical = Input.GetAxis(mouseYAxisName);


        // Mueve al jugador.
        controllerToMove.Move(controllerToMove.gameObject.transform.right * horizontalMovement + controllerToMove.gameObject.transform.up * playerToCheckJump.GetFallSpeed() + controllerToMove.gameObject.transform.forward * forwardMovement);

        transform.Rotate(0.0f, rotateHorizontal * sensitivity, 0.0f); // Lo rota.

        // C�digo para rotar la c�mara verticalmente.
        Vector3 rotation = camera.transform.localEulerAngles;
        rotation.x = (rotation.x - rotateVertical * sensitivity + 360) % 360;

        // Verifica si se pas� de los l�mites.
        if (rotation.x > verticalDownAngle && rotation.x < 180.0f)
        {
            rotation.x = verticalDownAngle;
        }
        else if (rotation.x < 280.0f && rotation.x > 180.0f)
        {
            rotation.x = 280.0f;
        }

        // Alinea la rotaci�n de la c�mara en Y al jugador.
        rotation.y = transform.rotation.eulerAngles.y;

        camera.transform.localEulerAngles = rotation;
        camera.transform.position = positionToGo.position;
    }
}
