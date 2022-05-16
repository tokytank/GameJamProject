using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionGet : MonoBehaviour {
    
    public string condition;
    public string targetItem;
    [TextArea]
    public string msgErr;
    [TextArea]
    public string msg2;
    bool first = true;
    bool In = false, have = false;
    void Update() {
        if (Gamemanager.gamemanager.Contain(condition)) {
            have = true;
        }
        if (In && !have && Input.GetKeyDown(KeyCode.F)) {
            TextControl.textControl.SetText(msgErr);
        } 
        if (first && In && have) {
            if (Input.GetKeyDown(KeyCode.F)) {
                Gamemanager.gamemanager.Add(targetItem);
                TextControl.textControl.SetText(msg2);
                first = false;
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
