using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCloseLaser : MonoBehaviour
{
    [SerializeField] float close = 4f;
    [SerializeField] float open = 2f;
    BoxCollider2D boxColliderLaser;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxColliderLaser = GetComponent<BoxCollider2D>();
        StartCoroutine(OpenCloseLaser());
    }
    IEnumerator OpenCloseLaser() {
        while (true) {
            yield return new WaitForSeconds(close);
            transform.localScale = new Vector3 ( 0, 2.5f, 1f); 
            boxColliderLaser.enabled = false;
            yield return new WaitForSeconds(open);
            transform.localScale = new Vector3(1, 2.5f, 1f);
            boxColliderLaser.enabled = true;
        }
    }
}
