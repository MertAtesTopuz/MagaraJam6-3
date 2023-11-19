using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public static Throw instance;

    public GameObject thrObj;
    public GameObject pos;
    public bool canThrow;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canThrow == true)
            {
                Instantiate(thrObj, pos.transform.position, Quaternion.identity);
                StartCoroutine(ThrowTime());
            } 
        }
    }

    IEnumerator ThrowTime()
    {
        canThrow = false;
        yield return new WaitForSeconds(2f);
        canThrow = true;
    }

}
