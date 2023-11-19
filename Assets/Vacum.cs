using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacum : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();

        if (otherRb != null)
        {
            otherRb.AddForce(transform.right * 10f * playerMovement.instance.faceCheck, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();

        if (otherRb != null)
        {
            otherRb.AddForce(transform.right * 10f * playerMovement.instance.faceCheck, ForceMode2D.Impulse);
        }
    }
}
