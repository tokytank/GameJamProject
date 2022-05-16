using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    bool girlIn, robotIn;
    public DoorMove door;
    void Start() {
        
    }

    void Update() {
        if (girlIn) {
            if (Input.GetKeyDown(KeyCode.F)) {
                door.Move();
            }
        }
        if (robotIn) {
            if (Input.GetKeyDown(KeyCode.RightControl)) {
                door.Move();
            }
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
