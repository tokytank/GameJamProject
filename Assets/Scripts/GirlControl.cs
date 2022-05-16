using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlControl : MonoBehaviour {
    private const float EPS = 1e-4f;
    private Rigidbody2D rb;
    public float speed = 10;
    public float jumpForce = 10;
    public bool canJump = true;
    public Animator anim;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        MoveControl();
        switchAnim();
    }
    void MoveControl() {
        float moveSpeed = Input.GetAxis("Horizontal");
        float faceDir = Input.GetAxisRaw("Horizontal");
        transform.localScale = new Vector3(faceDir == 0 ? transform.localScale.x : faceDir * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        if (moveSpeed != 0) { 
            rb.velocity = new Vector2(moveSpeed * speed, rb.velocity.y);
        } 
        if (Input.GetAxis("Vertical") > 0 && canJump) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void switchAnim()
    {
        if(rb.velocity.x!=0&&rb.velocity.y==0)
        {
            anim.SetBool("walking", true);
            anim.SetBool("idle", false);
            anim.SetBool("jumping", false);
            anim.SetBool("falling", false);
        }
        else if(rb.velocity.x==0 && rb.velocity.y == 0)
        {
            anim.SetBool("walking", false);
            anim.SetBool("idle", true);
            anim.SetBool("falling", false);
            anim.SetBool("jumping", false);
        }
        else if(rb.velocity.y > 0&&Input.GetButtonDown("Vertical"))
        {
            anim.SetBool("jumping", true);
            anim.SetBool("idle", false);
        }
        else if(rb.velocity.y<0)
        {
            anim.SetBool("falling", true);
            anim.SetBool("jumping", false);
            anim.SetBool("walking", false);
        }
    }
}
