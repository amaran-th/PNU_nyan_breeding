using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeButton : MonoBehaviour
{
    public float animTime = 3f;
    public Image fadeImage;
    public GameObject loadbtn;
    public GameObject newbtn;
    //public GameObject[] loadbtn=new GameObject[2];
    //public GameObject[] newbtn=new GameObject[2];
    private Image btn1;
    private Image btn2;
    Color color1;
    ColorBlock colorBlock;
    private bool fade = false;

    void Awake() {
        fadeImage = GetComponent<Image>();
        color1 = fadeImage.color;  
        color1.a=0;
        fadeImage.color = color1;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        loadbtn.SetActive(false);
        newbtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("click11111111111");
            loadbtn.SetActive(true);
            newbtn.SetActive(true);
            StartCoroutine("FadeIn");
        }
    }

    IEnumerator FadeIn() {
        for (int i=0;i<10;i++) {
            float f = i/10.0f;
            Color color = color1;
            color.a = f;
            fadeImage.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        loadbtn.SetActive(true);
        newbtn.SetActive(true);
    }  
}
