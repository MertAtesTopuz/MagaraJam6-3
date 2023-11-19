using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCol : MonoBehaviour
{
    public GameObject globalLight;
    public GameObject ventLight;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerMovement.instance.crouchCheck == true)
            {
                playerMovement.instance.crouchCheck = false;
                playerMovement.instance.playerJumpSpeed -= 10f;
                globalLight.SetActive(true);
                ventLight.SetActive(false);
            }
            else if (playerMovement.instance.crouchCheck == false)
            {
                playerMovement.instance.crouchCheck = true;
                playerMovement.instance.playerJumpSpeed += 10f;
                globalLight.SetActive(false);
                ventLight.SetActive(true);
            }
        }
    }
}
