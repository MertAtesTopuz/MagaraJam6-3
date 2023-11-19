using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpassablePlat : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            PlayerOWP.instance.platTry = false;
        }
    }
}
