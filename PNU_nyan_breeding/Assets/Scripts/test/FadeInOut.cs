using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image image;
    bool state=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void Fade(){
        if(state){
            Debug.Log("Fade-In");
            StartCoroutine(FadeInCoroutine());
        }else{
            Debug.Log("Fade-Out");
            StartCoroutine(FadeOutCoroutine());
        }
        state=!state;
    }
    IEnumerator FadeInCoroutine(){
        float fadeCount=0;//처음 알파 값
        while(fadeCount<1.0f){
            fadeCount+=0.01f;
            yield return new WaitForSeconds(0.01f); //다음 프레임까지 대기
            image.color=new Color(0,0,0,fadeCount);
        }
    }
    IEnumerator FadeOutCoroutine(){
        float fadeCount=1;//처음 알파 값
        while(fadeCount>0f){
            fadeCount-=0.01f;
            yield return new WaitForSeconds(0.01f); //다음 프레임까지 대기
            image.color=new Color(0,0,0,fadeCount);
        }
    }
    
}
