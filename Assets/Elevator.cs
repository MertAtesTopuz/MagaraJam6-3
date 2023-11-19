using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform firstPos, secondPos;
    public float speed;

    Vector3 nextPos;

    private void Start()
    {
        nextPos = firstPos.position;
    }

    private void Update()
    {

        if (transform.position == secondPos.position)
        {
            StartCoroutine(Transform2());
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            StartCoroutine(Transform1());
        }
    }

    IEnumerator Transform1()
    {
        yield return new WaitForSeconds(1f);
        nextPos = secondPos.position;
    }

    IEnumerator Transform2()
    {
        yield return new WaitForSeconds(1f);
        nextPos = firstPos.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(firstPos.position, secondPos.position);
    }
}
