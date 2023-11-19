using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPos : MonoBehaviour
{
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(screenPos.y, screenPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
    }
}
