using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Judge : MonoBehaviour
{
    bool condition = false;
    public GameObject robot;
    void Update()
    {
        if (condition && robot.activeSelf) {
            if (Input.GetKeyDown(KeyCode.F)) {
                MySceneManager.mySceneManager.LoadScene(1);
            }
        }
        if (condition && !robot.activeSelf && Input.GetKeyDown(KeyCode.F)) {
            TextControl.textControl.SetText("在房间里再看看吧");
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
