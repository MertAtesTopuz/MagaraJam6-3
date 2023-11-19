using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingButtonPlatform : MonoBehaviour
{
    public Transform firstPos, secondPos;
    public float speed;
    public ButtonCode buton;
    Vector3 nextPos;

    private void Start()
    {
        nextPos = firstPos.position;

    }

    private void Update()
    {
        if (buton.isOn2 == true && transform.position == firstPos.position)
        {
            StartCoroutine(WaitTime1());
        }

        if (buton.isOn2 == false)
        {
            StartCoroutine(WaitTime2());
            
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    IEnumerator WaitTime1()
    {
        yield return new WaitForSeconds(1f);
        nextPos = secondPos.position;
    }
    IEnumerator WaitTime2()
    {
        yield return new WaitForSeconds(1f);
        nextPos = firstPos.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(firstPos.position, secondPos.position);
    }
}
