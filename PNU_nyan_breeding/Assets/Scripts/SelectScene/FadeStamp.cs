using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeStamp : MonoBehaviour
{

    public StartButton btn;
    public GameObject panel;

    private float speed=3f;
    private float time;

    Vector3 target = new Vector3(400.26f, 800, 0);
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<Image>().color;
        color.a=0;
        gameObject.GetComponent<Image>().color = color;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (btn.flag) {
            panel.SetActive(true);
            color.a=1;
            gameObject.GetComponent<Image>().color = color; 
            transform.localScale = Vector3.one * (1-time*speed);
            if (time > 0.2f) {
                time=0;
                btn.flag=false;
            }
            time+=Time.deltaTime;
        }
    }
}
