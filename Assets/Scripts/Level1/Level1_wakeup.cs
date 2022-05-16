using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_wakeup : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    GirlControl girlControl;
    void Start()
    {
        anim = GetComponent<Animator>();
        girlControl = GetComponent<GirlControl>();
        if (MySceneManager.mySceneManager.firstLoad) {
            MySceneManager.mySceneManager.firstLoad = false;
            anim.SetBool("awake", true);
            // StartCoroutine(first());
        }
    }

    void first() {
        // yield return new WaitForSeconds(2f);
        anim.SetBool("awake", false);
        anim.SetBool("idle", true);
        // yield return new WaitForSeconds(1f);
        girlControl.enabled = true;
    }
}
