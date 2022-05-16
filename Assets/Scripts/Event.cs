using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {
    public bool girlClick, robotClick;
    bool girlIn = false, robotIn = false;

    void Update() {
        if (girlIn && Input.GetKeyDown(KeyCode.F)) {
            
        } 
        if (robotIn && Input.GetKeyDown(KeyCode.RightControl)) {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (girlClick && other.tag == "girl") {
            girlIn = true;
        }
        if (robotClick && other.tag == "robot") {
            robotIn = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (girlClick && other.tag == "girl") {
            girlIn = false;
        }
        if (robotClick && other.tag == "robot") {
            robotIn = false;
        }
    }
}
