using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AngleMovment : MonoBehaviour
{
    [SerializeField] GameObject angle;
    [SerializeField] GameObject angleLight;
    [SerializeField] GameObject withAngleLight;
    [SerializeField] Vector3 angleWillGo;
    [SerializeField] float intensityAmount = 1.0f;
    [SerializeField] float openLightAmount = 1.0f;

    Animator animator;
    Light2D light2DEdit;
    void Start() {
        animator = angle.GetComponent<Animator>();
        light2DEdit = angleLight.GetComponent<Light2D>();
    }

    void Update() {

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            angle.transform.position = angleWillGo;
            animator.SetTrigger("Attack");
            light2DEdit.intensity = intensityAmount;
            StartCoroutine(OpenLightDelay());
        }
    }
    IEnumerator OpenLightDelay() {
        yield return new WaitForSeconds(openLightAmount);
        light2DEdit.intensity = 1;
    }
}
