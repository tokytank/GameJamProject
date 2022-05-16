using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour {
    bool f = false;
    public static Gamemanager gamemanager;
    public List<string> list;
    private void Awake() {
        if (gamemanager == null)
            gamemanager = this;
        DontDestroyOnLoad(gamemanager);
    }
    private void Start() {
        // Black = GetComponent<SpriteRenderer>();
        // Black.enabled = false;
        list = new List<string>();
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    private void Update() {
        escape();
    }
    public void escape() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }
    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void Developer(Image img) {
        f = !f;
        if (f) {
            img.color = new Color(1, 1, 1, 1);
        } else {
            img.color = new Color(1, 1, 1, 0);
        }
    }
    
    public void Add(string s) {
        if (!list.Contains(s)) {
            list.Add(s);
        }
    }
    public bool Contain(string s) {
        return list.Contains(s);
    }

}
