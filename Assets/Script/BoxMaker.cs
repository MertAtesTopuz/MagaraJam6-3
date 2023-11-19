using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMaker : MonoBehaviour
{
    public GameObject box;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 spawnPos = new Vector2(other.transform.position.x + 2, transform.position.y);
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(box, spawnPos, Quaternion.identity);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Vector2 spawnPos = new Vector2(other.transform.position.x + 2, transform.position.y);
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(box, spawnPos, Quaternion.identity);
            }
        }
    }
}
