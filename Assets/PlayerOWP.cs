using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOWP : MonoBehaviour
{
    public static PlayerOWP instance;

    private GameObject currentOneWayPlatform;

    private CapsuleCollider2D playerCol;

    public bool platTry;

    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        playerCol = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && platTry == true)
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCol, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCol, platformCollider, false);
    }
}
