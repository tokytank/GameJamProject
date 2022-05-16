using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public AudioClip audioClip;
    public Sprite image;
    bool In = false;
    [TextArea]public string msg;
    
    void Update() {
        if (In) {
            if (Input.GetKeyDown(KeyCode.F)) {
                ImgControl.imgControl.DispUI(image);
                Gamemanager.gamemanager.GetComponent<AudioSource>().Stop();
                Gamemanager.gamemanager.GetComponent<AudioSource>().clip = audioClip;
                Gamemanager.gamemanager.GetComponent<AudioSource>().Play();
                StartCoroutine(EndGame());
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

    public IEnumerator EndGame() {
        yield return new WaitForSeconds(10f);
        // ImgControl.imgControl.image.color = new Color(0, 0, 0, 0);
        MySceneManager.mySceneManager.Black.color = new Color(0, 0, 0, 0);
        while (true)
        {
            ImgControl.imgControl.image.color -= new Color(0, 0, 0, 0.1f * Time.deltaTime);
            MySceneManager.mySceneManager.Black.color += new Color(0, 0, 0, 0.1f * Time.deltaTime);
            yield return 0;
            if (MySceneManager.mySceneManager.Black.color.a >= 1)
                break;
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
