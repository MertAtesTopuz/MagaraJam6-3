using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenCol : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraMain;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(7f, -16f, player.transform.position.z);
            cameraMain.transform.position = new Vector3(0f, -15.5f, cameraMain.transform.position.z);
        }
    }
}
