using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFloat : MonoBehaviour
{
    float time = 0;
    int i = 0;
    Vector3 transfPos;
    Rigidbody2D rb;
    RobotControl robotControl;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        robotControl = GetComponent<RobotControl>();
    }

    // Update is called once per frame
    void Update() {
        transfPos = this.transform.position;
        time += Time.deltaTime;
        if (time > 0.1) {
            if (rb.velocity == Vector2.zero && !robotControl.touchGround) {
                i = (i + 1) % 4;
                if (i == 0) {
                    transfPos = this.transform.position;
                    this.transform.position = new Vector3(transfPos.x, transfPos.y + 0.01f, transfPos.z);
                }
                if (i == 1) {
                    transfPos = this.transform.position;
                    this.transform.position = new Vector3(transfPos.x, transfPos.y, transfPos.z);
                }
                if (i == 2) {
                    transfPos = this.transform.position;
                    this.transform.position = new Vector3(transfPos.x, transfPos.y - 0.01f, transfPos.z);
                }
                if (i == 3) {
                    transfPos = this.transform.position;
                    this.transform.position = new Vector3(transfPos.x, transfPos.y, transfPos.z);
                }
            }
            time = 0;
        }
    }
}
