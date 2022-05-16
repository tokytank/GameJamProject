using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyControl : MonoBehaviour {
    public float energyMax = 5;
    public float energy = 5;
    public float CostSpeed = 1f;
    float time = 0;
    RobotControl robotControl;
    // public float Energy {
    //     get => energy;
    // }
    void Start() {
        energy = energyMax;
        robotControl = GetComponent<RobotControl>();
    }

    void Update() {
        time += Time.deltaTime;
        if (time > 0.1) {
            if (Input.GetAxis("Vertical2") > 0) {
                if (energy > 0) energy -= CostSpeed;
            } 
            if (robotControl.touchGround && energy <= energyMax) {
                if (energy < energyMax) energy += CostSpeed;
            }
            time = 0;
        }
        if (energy < 0) {
            energy = 0;
        }
        if (energy > energyMax) {
            energy = energyMax;
        }
    }
}
