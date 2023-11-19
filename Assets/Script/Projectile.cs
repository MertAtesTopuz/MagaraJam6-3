using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject pushPos;
    private GameObject player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        pushPos = GameObject.FindGameObjectWithTag("PushPos");
        rb.AddForce( pushPos.transform.up *10, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y + 2, player.transform.position.z);
            Destroy(this.gameObject);
        }
    }
}
