using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFirstPerson : MonoBehaviour
{
    [Header("Button Names")]
    [SerializeField] string mouseXAxisName = ""; // Hago esto para no tener que modificar el código si en algún momento
    [SerializeField] string mouseYAxisName = ""; // se nos ocurre cambiarle el nombre desde el Input Manager.

    [Header("References")]
    [SerializeField] Camera camera = null; // Literalmente la cámara.
    [SerializeField] Transform positionToGo = null; // El punto donde va a ir la cámara (el gameObject de la posición).
    [SerializeField] CharacterController controllerToMove = null; // El controlador del jugador.
    [SerializeField] PlayerMovement playerToCheckJump = null; // El código de movimiento del jugador, para poder
                                                              // saltar en 1ra persona.
                                                              // Tranquilamente podría hacer un GetComponent en el Awake,
                                                              // pero me pareció más claro hacerlo de esta forma.

    [Header("Speed Configuration")]
    [SerializeField] float sensitivity = 0.0f; // Sensibilidad de la cámara. Debería ser la misma que el movimiento de
                                               // giro del jugador.

    [Header("Angle Configuration")]
    [SerializeField] float verticalDownAngle = 0.0f; // Qué tanto puede mirar hacia abajo (en grados). 80 es ideal.



    void Update()
    {
        playerToCheckJump.CheckJump(); // Sirve también para actualizar la gravedad.
        RotatoryMotion(); // Para rotar la cámara y el jugador (este último lo rota sobre el eje Y, hacia los costados).
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

        // Código para rotar la cámara verticalmente.
        Vector3 rotation = camera.transform.localEulerAngles;
        rotation.x = (rotation.x - rotateVertical * sensitivity + 360) % 360;

        // Verifica si se pasó de los límites.
        if (rotation.x > verticalDownAngle && rotation.x < 180.0f)
        {
            rotation.x = verticalDownAngle;
        }
        else if (rotation.x < 280.0f && rotation.x > 180.0f)
        {
            rotation.x = 280.0f;
        }

        // Alinea la rotación de la cámara en Y al jugador.
        rotation.y = transform.rotation.eulerAngles.y;

        camera.transform.localEulerAngles = rotation;
        camera.transform.position = positionToGo.position;
    }
}
