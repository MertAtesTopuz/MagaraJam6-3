using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserOpenCloseNotWay : MonoBehaviour
{
    [SerializeField] float openDelay = 1.0f;    
    [SerializeField] float closeDelay = 1.0f;
    BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(LaserOpenClose());
    }


    void Update()
    {
        
    }
    IEnumerator LaserOpenClose() {
        while (true) {
            yield return new WaitForSeconds(closeDelay);
            boxCollider.enabled = false;
            transform.localScale = new Vector3 (0.0f, 1f, 1.0f);
            yield return new WaitForSeconds(openDelay);
            boxCollider.enabled = true;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
