using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMachine : MonoBehaviour
{
    [SerializeField] float fireOpenDelay = 1f;
    [SerializeField] float fireCloseDelay = 1f;

    BoxCollider2D boxCollider2D;
    Animator animator;

    void Start()
    {
        StartCoroutine(FireMachineOpenClose());
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    IEnumerator FireMachineOpenClose() {
        while (true) {
            yield return new WaitForSeconds(fireCloseDelay);
            transform.localScale = new Vector3(0f, 1, 16);
            boxCollider2D.enabled = false;
            animator.SetBool("FireMove", false);
            yield return new WaitForSeconds(fireOpenDelay);
            transform.localScale = new Vector3(1, 1, 16);
            boxCollider2D.enabled = true;
            animator.SetBool("FireMove", true);
        }
    }
}
