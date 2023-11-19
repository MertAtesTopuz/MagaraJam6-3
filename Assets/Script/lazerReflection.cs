using UnityEngine;

public class LaserReflection : MonoBehaviour {
    [SerializeField] Transform sourceObject;
    [SerializeField] const short maxReflection = 4;
    [SerializeField] short currentReflection = 0;
    [SerializeField] float raycastDistance = 1.0f;
    [SerializeField] LineRenderer lineRenderer;

    RaycastHit2D hit;

    void Update() {
        CalculateLaser();
    }

    void CalculateLaser() {
        if (CheckIfHitSurface(sourceObject.position, sourceObject.up)) {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = maxReflection + 3;
            lineRenderer.SetPosition(0, sourceObject.position); // Starting point
            DrawLaser(sourceObject.position, sourceObject.up);
        } else {
            lineRenderer.enabled = false;
        }
    }

    bool CheckIfHitSurface(Vector2 startPos, Vector2 laserDirection) {
        hit = Physics2D.Raycast(startPos, laserDirection, raycastDistance, LayerMask.GetMask("Wall"));
        return hit.collider != null;
    }

    void DrawLaser(Vector2 startPos, Vector2 laserDirection, bool continueChecking = true) {
        if (currentReflection <= maxReflection) { Debug.Log("31");
            lineRenderer.SetPosition(currentReflection, startPos); // Starting point

            currentReflection++;
            if (continueChecking) {
                Vector2 oldPos = hit.point;
                Vector2 oldDirection = Vector2.Reflect(laserDirection, hit.normal);

                hit = Physics2D.Raycast(oldPos, oldDirection, raycastDistance, LayerMask.GetMask("Wall"));
                if (hit.collider != null) {
                    DrawLaser(oldPos, oldDirection, true);
                } else {
                    lineRenderer.SetPosition(maxReflection - currentReflection, oldPos + oldDirection * raycastDistance);
                }
            }
        }
    }
}