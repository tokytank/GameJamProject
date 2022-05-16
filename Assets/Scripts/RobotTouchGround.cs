using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTouchGround : MonoBehaviour {

    public RobotControl robotControl;
    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ground") {
            robotControl.touchGround = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "ground") {
            robotControl.touchGround = false;
        }
    }

}
