using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgControl : MonoBehaviour
{
    public static ImgControl imgControl;
    Coroutine coroutine = null;
    public Image image;
    // Start is called before the first frame update
    private void Awake() {
        imgControl = this;
    }
    void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            if (coroutine != null)   StopCoroutine(coroutine);
            coroutine = StartCoroutine(hiddenImg2());
        }
    }
    
    public void DispUI(Sprite img, bool f = false) {
        image.color = new Color(1, 1, 1, 1);
        image.sprite = img;
        // image.SetNativeSize();
        if (f) {
            if (coroutine != null)   StopCoroutine(coroutine);
            coroutine = StartCoroutine(hiddenImg());
        }
    }
    
    IEnumerator hiddenImg() {   
        yield return new WaitForSeconds(15f);
        while (true)
        {
            image.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
            yield return 0;
            if (image.color.a <= 0)
                break;
        }
        image.color = new Color(1, 1, 1, 0);
    }
    IEnumerator hiddenImg2() {   
        while (true)
        {
            image.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
            yield return 0;
            if (image.color.a <= 0)
                break;
        }
        image.color = new Color(1, 1, 1, 0);
    }
}
