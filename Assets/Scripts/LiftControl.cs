using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftControl : MonoBehaviour {
    bool condition = false;
    public GameObject bg, bg1;
    public JudgeNextLevel judgeNextLevel;
    public GirlControl girlControl;
    public RobotControl robotControl;
    Coroutine coroutine;
    float time = 0;
    bool wait = false;
    bool f = true;
    void Start() {
        judgeNextLevel.nextLevel = 1;
        f = true;
    }

    void Update() {
        if (condition) {
            if (!wait && Input.GetKeyDown(KeyCode.F)) {
                if (coroutine != null)  StopCoroutine(coroutine);
                coroutine = StartCoroutine(MySceneManager.mySceneManager.TurnToBlack());
                wait = true;
                girlControl.enabled = false;
                robotControl.enabled = false;
            }
        }
        // 播放音乐并等待结束
        if (wait) {
            time += Time.deltaTime;
            if (time > 3) {
                if (f) {
                    bg.SetActive(false);
                    bg1.SetActive(true);
                    judgeNextLevel.nextLevel = 3;
                } else {
                    bg1.SetActive(false);
                    bg.SetActive(true);
                    judgeNextLevel.nextLevel = 1;
                }
                if (coroutine != null)  StopCoroutine(coroutine);
                coroutine = StartCoroutine(MySceneManager.mySceneManager.TurnToWhite());
                f = !f;
                wait = false;
                girlControl.enabled = true;
                robotControl.enabled = true;
                time = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "girl") {
            condition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "girl") {
            condition = false;
        }
    }
}
