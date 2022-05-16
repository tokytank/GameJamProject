using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryControl : MonoBehaviour
{
    private float time = 0;
    public float batteryMax = 10;
    public float batteryCostSpeed = 5f;
    public float battery = 0;
    public bool charge = false;
    public bool canTouch = true;
    EnergyControl energyControl;
    RobotControl robotControl;
    void Start() {
        energyControl = GetComponent<EnergyControl>();
        robotControl = GetComponent<RobotControl>();
    }

    void Update() {
        time += Time.deltaTime;
        if (time > 1) {
            if (charge) {
                battery = batteryMax;
            } else {
                if (battery > 0)    battery -= batteryCostSpeed;
                if (battery < 0)    battery = 0;
            }
            time = 0;
        }
        if (battery <= 0) {
            energyControl.energyMax = 5;
            robotControl.speed = 3;
        } else {
            energyControl.energyMax = 100;
            robotControl.speed = 5;
        }
    }
    
}
