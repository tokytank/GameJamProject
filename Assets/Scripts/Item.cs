using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public string itemname;
    [TextArea]
    public string msg;
    public bool girlClick, robotClick;
    bool girlIn = false, robotIn = false;

    void Update() {
        if (girlClick && girlIn && Input.GetKeyDown(KeyCode.F)) {
            Gamemanager.gamemanager.Add(itemname);
            TextControl.textControl.SetText(msg);
            Destroy(this.gameObject);
        } 
        if (!girlClick && girlIn && Input.GetKeyDown(KeyCode.F)) {
            TextControl.textControl.SetText("我够不到。");
        }
        if (robotClick && robotIn && Input.GetKeyDown(KeyCode.RightControl)) {
            Gamemanager.gamemanager.Add(itemname);
            TextControl.textControl.SetText(msg);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "girl") {
            girlIn = true;
        }
        if (other.tag == "robot") {
            robotIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "girl") {
            girlIn = false;
        }
        if (other.tag == "robot") {
            robotIn = false;
        }
    }
}
