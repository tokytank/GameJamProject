using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour {
    public static TextControl textControl;
    Coroutine coroutine = null;
    Text msg;
    private void Awake() {
        textControl = this;
    }
    private void Start() {
        msg = GetComponent<Text>();
    }
    public void SetText(string s) {
        msg.color = new Color(1, 1, 1, 1);
        msg.text = s;
        if (coroutine != null)   StopCoroutine(coroutine);
        coroutine = StartCoroutine(hidden());
    }
    IEnumerator hidden() {   
        yield return new WaitForSeconds(2f);
        while (true)
        {
            msg.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
            yield return 0;
            if (msg.color.a <= 0)
                break;
        }
        msg.color = new Color(1, 1, 1, -1);
    }
}
