using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeNextLevel : MonoBehaviour
{
    bool condition = false;
    public int nextLevel;
    void Update()
    {
        if (condition) {
            if (Input.GetKeyDown(KeyCode.F)) {
                MySceneManager.mySceneManager.LoadScene(nextLevel);
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
