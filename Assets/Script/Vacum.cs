using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacum : MonoBehaviour
{
    private BoxCollider2D col;
    private SpriteRenderer render;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            col.enabled = true;
            render.enabled = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            col.enabled = false;
            render.enabled = false;
        }
    }

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
