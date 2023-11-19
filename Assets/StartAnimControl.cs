using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimControl : MonoBehaviour
{
    public Animator anim;
    public GameObject cha;
    public bool animCheck = true;

    void Update()
    {
        if (MenuController.instance.uIFalse == true)
        {
            if (animCheck)
            {
                if (Input.anyKey)
                {
                    StartCoroutine(AnimTime());
                    animCheck = false;
                }
            }

        }

    }

    IEnumerator AnimTime()
    {
        anim.SetBool("isPressS", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isPressS", false);
        yield return new WaitForSeconds(1f);
        cha.SetActive(true);
    }
}
