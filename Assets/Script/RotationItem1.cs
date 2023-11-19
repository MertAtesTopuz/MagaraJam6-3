using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationItem1 : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 160f;

    void Update() {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z * rotationSpeed);
    }
}
