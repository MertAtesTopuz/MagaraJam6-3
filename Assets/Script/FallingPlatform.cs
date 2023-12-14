using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Animator anim;
    public float animWait;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            StartCoroutine(FallTime());
        }
    }

    IEnumerator FallTime()
    {
        anim.SetBool("isFalling", true);
        yield return new WaitForSeconds(animWait);
        anim.SetBool("isFalling", false);
    }
}
