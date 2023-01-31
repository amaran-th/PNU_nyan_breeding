using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadebut : MonoBehaviour
{
    public float animTime = 3f;
    public Text fadeText;

    private float start = 1f;
    private float end = 0f;
    private float time = 0f;

    Color color2;
    public bool fade = true;

    void Awake() {
        fadeText = GetComponent<Text>();
        Debug.Log(fadeText.text);
        color2 = fadeText.color;
        color2.a=0;
        fadeText.color = color2; 
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && fade) {
            Debug.Log("click");
            //PlayFadeIn();
            StartCoroutine("FadeIn");
        }
    }

    IEnumerator FadeIn() {
        fade = false;
        for (int i=0;i<10;i++) {
            float f = i/10.0f;
            Color color = color2;
            color.a = f;
            fadeText.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }  
}
