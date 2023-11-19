using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationItem : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 160f;
    [SerializeField] float rotationScale = 60f;

    void Update() {
        float rotationSpike = Mathf.Sin(Time.time * rotationSpeed * Mathf.Deg2Rad) * rotationScale;
        transform.rotation = Quaternion.Euler(0, 0, rotationSpike);
    }
}
