using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionJump : MonoBehaviour {
    public int index;
    [TextArea]
    public string msg;
    public string condition;
    bool In = false, have = false;
    void Update() {
        if (Gamemanager.gamemanager.Contain(condition)) {
            have = true;
        }
        if (In && !have && Input.GetKeyDown(KeyCode.F)) {
            TextControl.textControl.SetText(msg);
        } 
        if (In && have) {
            if (Input.GetKeyDown(KeyCode.F)) {
                MySceneManager.mySceneManager.LoadScene(index);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "girl") {
            In = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "girl") {
            In = false;
        }
    }
}
