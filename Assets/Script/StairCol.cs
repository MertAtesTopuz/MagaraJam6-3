using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairCol : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraMain;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(6.5f, -8f, player.transform.position.z);
            cameraMain.transform.position = new Vector3(0f, -8f, cameraMain.transform.position.z);
        }
    }
}
