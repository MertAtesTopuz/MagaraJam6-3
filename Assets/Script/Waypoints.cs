using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] float thingSpeed = 1.0f;
    [SerializeField] bool rePlay = true;
    [SerializeField] float newScaleX = -1f;
    [SerializeField] float newScaleY = 1f;
    [SerializeField] float newScaleZ = 1f;
    [SerializeField] float otherNewScaleX = 1f;
    [SerializeField] float otherNewScaleY = 1f;
    [SerializeField] float otherNewScaleZ = 1f;

    int currentIndex = 0;

    SpriteRenderer spriteRenderer;
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        Moving();
    }
    void Moving() {
        if (Vector2.Distance(wayPoints[currentIndex].transform.position, transform.position) < Mathf.Epsilon) {
            currentIndex++;
            if (currentIndex >= wayPoints.Length) {
                currentIndex = 0;
                if (!rePlay) {
                    Destroy(gameObject);
                }
            }
        }
        Vector3 direction = wayPoints[currentIndex].transform.position - transform.position;
        if (direction.x > 0) {
            transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
        } else if (direction.x < 0) {
            transform.localScale = new Vector3(otherNewScaleX, otherNewScaleY, otherNewScaleZ);
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentIndex].transform.position, thingSpeed * Time.deltaTime);
    }
}
