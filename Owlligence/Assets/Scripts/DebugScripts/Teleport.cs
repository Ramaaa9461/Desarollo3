using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<Transform> teleportPositions;
    PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {

        if (playerMovement.debugMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                playerMovement.enabled = false;
                player.transform.position = teleportPositions[0].position;
                playerMovement.enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                playerMovement.enabled = false;
                player.transform.position = teleportPositions[1].position;
                playerMovement.enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                playerMovement.enabled = false;
                player.transform.position = teleportPositions[2].position;
                playerMovement.enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                playerMovement.enabled = false;
                player.transform.position = teleportPositions[3].position;
                playerMovement.enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                playerMovement.enabled = false;
                player.transform.position = teleportPositions[4].position;
                playerMovement.enabled = true;
            }

        }
    }
}
