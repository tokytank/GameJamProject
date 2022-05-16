using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEvent : MonoBehaviour
{
    public Sprite image;
    bool In = false;
    [TextArea]public string msg;
    
    void Update() {
        if (In) {
            if (Input.GetKeyDown(KeyCode.F)) {
                ImgControl.imgControl.DispUI(image);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "girl") {
            In = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "girl") {
            In = false;
        }
    }
}
