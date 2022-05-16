using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 10;
    public float jumpForce = 10;
    public bool canFly;
    public bool touchGround = false;
    Animator animator;
    private EnergyControl energyControl;
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        energyControl = GetComponent<EnergyControl>();
        canFly = true;
    }

    void Update() {
        MoveControl();
    }
    void MoveControl() {
        float moveSpeedX = Input.GetAxis("Horizontal2") * speed;
        // float moveSpeedY = Input.GetAxis("Vertical2");
        if (energyControl.energy <= 0) {
            canFly = false;
            rb.gravityScale = 1;
        } else if (energyControl.energy >= 5) {
            canFly = true;
            rb.gravityScale = 0;
        }
        if (energyControl.energy <= 0 || touchGround) {
            animator.SetBool("Energy", false);
        } else {
            animator.SetBool("Energy", true);
        }
        if (Input.GetAxis("Vertical2") > 0 && canFly) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        } else if (Input.GetAxis("Vertical2") < 0 && canFly) {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        } else if (canFly) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        float faceDir = -1 * Input.GetAxisRaw("Horizontal2");
        transform.localScale = new Vector3(faceDir == 0 ? transform.localScale.x : faceDir * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        rb.velocity = new Vector2(moveSpeedX, rb.velocity.y);
    }
}
