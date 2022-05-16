using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScene : MonoBehaviour
{
    public int index;
    bool condition = false;
    void Update()
    {
        if (condition) {
            if (Input.GetKeyDown(KeyCode.F)) {
                MySceneManager.mySceneManager.LoadScene(index);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "girl") {
            condition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "girl") {
            condition = false;
        }
    }

}
