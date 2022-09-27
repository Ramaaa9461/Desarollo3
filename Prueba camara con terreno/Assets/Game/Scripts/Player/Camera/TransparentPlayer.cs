using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    Material playerMat;

    private void Awake()
    {
        playerMat = player.GetComponent<Material>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 4)
        {
            playerMat.color = new Color(playerMat.color.r, playerMat.color.g, playerMat.color.b, 0.0f);
        }
        else
        {
            playerMat.color = new Color(playerMat.color.r, playerMat.color.g, playerMat.color.b, 0.0f);
        }
    }
}
