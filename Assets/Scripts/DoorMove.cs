using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour {
    public Transform target;
    Vector3 targetPos;
    Vector3 originPos;
    Vector3 moveDir;
    bool move = false;
    float time = 0;
    BoxCollider2D boxCollider2D;
    void Start() {
        boxCollider2D = GetComponent<BoxCollider2D>();
        targetPos = target.position;
        originPos = this.transform.position;
        moveDir = targetPos - originPos;
    }
    
    void Update() {
        time += Time.deltaTime;
        if (time > 0.1) {
            if (move) {
                transform.position += moveDir * 0.05f;
            }
            if (transform.position == targetPos) {
                boxCollider2D.enabled = false;
                move = false;
            }
            time = 0;
        }
    }
    public void Move() {
        if (!move) {
            moveDir = targetPos - this.transform.position;
            move = true;
        }
    }
}
