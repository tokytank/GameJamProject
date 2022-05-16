using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismControl : MonoBehaviour {
    
    public DoorMove doorMove;
    void Start() {
        
    }
    
    void Update() {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "girl") {
            doorMove.Move();
        }
    }
}
