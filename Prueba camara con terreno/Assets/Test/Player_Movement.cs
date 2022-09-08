using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody RG;
    [SerializeField] float velocity;
    [SerializeField] [Range(0.1f, 1f)] float quaternionLerp;

    private void Awake()
    {
        RG = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {


     //   RG.AddForce(GetInputDirection());
        
      //  RG.rotation = TerrainInclination();

      //  RG.rotation = Quaternion.Lerp(RG.rotation, TerrainInclination(), quaternionLerp);
        transform.rotation = Quaternion.Lerp(RG.rotation, TerrainInclination(), quaternionLerp);
    }

    Vector3 GetInputDirection()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        float jumpForce = 0.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpForce = 500;
            Debug.Log("Salto");
        }

        Vector3 direction = new Vector3(movimientoH * velocity, jumpForce, movimientoV * velocity);

        return direction;
    }

    Quaternion TerrainInclination()
    {
        Quaternion inclination = Quaternion.identity;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

          //  inclination = Quaternion.Euler( hit.normal);

            inclination = hit.transform.rotation;
        }


        return inclination;
    }

}
