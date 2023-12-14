using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLvl : MonoBehaviour
{
    [SerializeField] float delay;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {

            collision.GetComponent<playerMovement>().DisablePlayer();
            StartCoroutine(LoadLvl());
        }
    }
    IEnumerator LoadLvl() {
        yield return new WaitForSeconds(delay);
        Debug.Log("nextlevel");
        int lvlIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLvlIndex = lvlIndex + 1;

        if (nextLvlIndex == SceneManager.sceneCountInBuildSettings) {
            nextLvlIndex = 0;
        }
        SceneManager.LoadScene(nextLvlIndex);
    }
}
