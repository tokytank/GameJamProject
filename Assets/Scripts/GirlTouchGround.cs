using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlTouchGround : MonoBehaviour {

    public GirlControl girlControl;
    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ground") {
            girlControl.canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "ground") {
            girlControl.canJump = false;
        }
    }

}
