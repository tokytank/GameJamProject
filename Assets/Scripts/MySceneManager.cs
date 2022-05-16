using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour {
    public static MySceneManager mySceneManager;
    Coroutine coroutine;
    public List<GameObject> cameras;
    public List<GameObject> cinemachines;
    public List<GameObject> grils;
    public List<GameObject> robots;
    int nowSceneIndex;
    public bool firstLoad = true;

    public SpriteRenderer Black;
    private void Awake() {
        mySceneManager = this;
    }

    void Start() {
        coroutine = null;
        nowSceneIndex = 0;
        for (int i = 0; i < cameras.Count; i++) {
            cameras[i].SetActive(false);
            cinemachines[i].SetActive(false);
            grils[i].SetActive(false);
            robots[i].SetActive(false);
        }
        StartGame();
    }

    public void StartGame() {
        nowSceneIndex = 0;
        cameras[nowSceneIndex].SetActive(true);
        cinemachines[nowSceneIndex].SetActive(true);
        grils[nowSceneIndex].SetActive(true);
        // robots[nowSceneIndex].SetActive(true);
    } 

    public void LoadScene(int index) {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(JumpLevel(index));
    }

    IEnumerator JumpLevel(int index) {
        ImgControl.imgControl.image.color = new Color(1, 1, 1, 0);
        Black.color = new Color(0, 0, 0, 0);
        while (true)
        {
            Black.color += new Color(0, 0, 0, Time.deltaTime);
            yield return 0;
            if (Black.color.a >= 1)
                break;
        }
        cameras[nowSceneIndex].SetActive(false);
        cinemachines[nowSceneIndex].SetActive(false);
        grils[nowSceneIndex].SetActive(false);
        robots[nowSceneIndex].SetActive(false);
        cameras[index].SetActive(true);
        cinemachines[index].SetActive(true);
        grils[index].SetActive(true);
        robots[index].SetActive(true);
        EnergyDisp.energyDisp.energyControl = robots[index].GetComponent<EnergyControl>();
        nowSceneIndex = index;
        Black.color = new Color(0, 0, 0, 1);
        while (true)
        {
            Black.color -= new Color(0, 0, 0, Time.deltaTime);
            yield return 0;
            if (Black.color.a <= 0)
                break;
        }
    }
    public IEnumerator TurnToBlack() {
        Black.color = new Color(0, 0, 0, 0);
        while (true)
        {
            Black.color += new Color(0, 0, 0, Time.deltaTime);
            yield return 0;
            if (Black.color.a >= 1)
                break;
        }
    }
    public IEnumerator TurnToWhite() {
        Black.color = new Color(0, 0, 0, 1);
        while (true)
        {
            Black.color -= new Color(0, 0, 0, Time.deltaTime);
            yield return 0;
            if (Black.color.a <= 0)
                break;
        }
    }
}

