using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickControl : MonoBehaviour {
    bool girlIn;
    public DoorMove door;
    void Start() {
        
    }

    void Update() {
        if (girlIn) {
            if (Input.GetKeyDown(KeyCode.F)) {
                door.Move();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "girl") {
            girlIn = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "girl") {
            girlIn = false;
        }
    }
}
