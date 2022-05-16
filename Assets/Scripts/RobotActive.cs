using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotActive : MonoBehaviour
{
    public GameObject robot;
    public GameObject curtain1, curtain;
    bool setAct = false;
    void Update()
    {
        if (setAct) {
            if (Input.GetKeyDown(KeyCode.F)) {
                robot.SetActive(true);
                curtain.SetActive(false);
                curtain1.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "girl") {
            setAct = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "girl") {
            setAct = false;
        }
    }
}
