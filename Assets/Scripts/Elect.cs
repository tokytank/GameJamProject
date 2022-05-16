using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elect : MonoBehaviour
{
    public BoxCollider2D bc;
    public Sprite elect1;
    SpriteRenderer sprite;
    [TextArea]
    public string msgErr;
    [TextArea]
    public string msg2;
    bool In = false, have = false;
    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update() {
        if (Gamemanager.gamemanager.Contain("Type") && Gamemanager.gamemanager.Contain("Handler") && Gamemanager.gamemanager.Contain("Wood")) {
            have = true;
        }
        if (In && !have && Input.GetKeyDown(KeyCode.F)) {
            TextControl.textControl.SetText(msgErr);
        } 
        if (In && have) {
            if (Input.GetKeyDown(KeyCode.F)) {
                Gamemanager.gamemanager.Add("Elect");
                TextControl.textControl.SetText(msg2);
                sprite.sprite = elect1;
                bc.enabled = false;
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
