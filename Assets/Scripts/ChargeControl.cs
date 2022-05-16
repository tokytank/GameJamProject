using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeControl : MonoBehaviour {
    BatteryControl batteryControl;
    bool near = false;
    void Start() {
        batteryControl = GetComponent<BatteryControl>();
    }

    void Update() {
        if (Gamemanager.gamemanager.Contain("Chip")) {
            if (near) {
                batteryControl.charge = true;
            } else {
                batteryControl.charge = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "charge") {
            near = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "charge") {
            near = false;
        }
    }
}
