using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivityController : MonoBehaviour
{
    public GameObject plan;
    public GameObject[] activities=new GameObject[3];
    public GameObject nextButton;
    public static bool trigger;

    Color[] colors = new Color[3];
    Vector3 target = new Vector3(400.26f, 800, 0);
    private float speed=1f;
    private float time;
    bool[] fadeins = {true, true, true};

    void Start()
    {
        for(int i=0;i<3;i++){
            colors[i]=activities[i].transform.Find("Illust").GetComponent<Image>().color;
            colors[i].a=0;
            activities[i].transform.Find("Illust").GetComponent<Image>().color = colors[i];
        }
    }
    
    void Awake(){
        trigger=false;
    }
    void Update(){
        if(trigger){
            trigger=false;
            LoadIllust();
            Invoke("ViewFirstActivity",1f);
        }

        if (activities[0].activeSelf && fadeins[0]) {
            colors[0].a=1;
            activities[0].transform.Find("Illust").GetComponent<Image>().color = colors[0]; 
            activities[0].transform.localScale = Vector3.one * (1-time*speed);
            if (time > 0.2f) {
                time=0;
                fadeins[0]=false;
            }
            time+=Time.deltaTime;
        }

        if (activities[1].activeSelf && fadeins[1]) {
            colors[1].a=1;
            activities[1].transform.Find("Illust").GetComponent<Image>().color = colors[1]; 
            activities[1].transform.localScale = Vector3.one * (1-time*speed);
            if (time > 0.2f) {
                time=0;
                fadeins[1]=false;
            }
            time+=Time.deltaTime;
        }

        if (activities[2].activeSelf && fadeins[2]) {
            colors[2].a=1;
            activities[2].transform.Find("Illust").GetComponent<Image>().color = colors[2]; 
            activities[2].transform.localScale = Vector3.one * (1-time*speed);
            if (time > 0.2f) {
                time=0;
                fadeins[2]=false;
            }
            time+=Time.deltaTime;
        }
    }
    void LoadIllust(){
        for(int i=0;i<3;i++){
            //TODO Activity에 gif_path, info 추가 
            activities[i].transform.Find("Illust").GetComponent<Image>().sprite=Resources.Load<Sprite>(CalenderController.scheduleList[i].img_path) as Sprite;
            //activities[i].transform.Find("Illust").GetComponent<Animator>().SetInteger("activity_type",2);
            activities[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text=CalenderController.scheduleList[i].name+"을 했다!";
            
        }
    }

    public void ViewActivity(){
        Invoke("ViewFirstActivity",1f);
    }
    void ViewFirstActivity(){
        trigger=false;
        activities[0].SetActive(true);
        activities[0].transform.Find("Illust").GetComponent<Animator>().SetInteger("activity_type",2); //임시로 activity_type을 2로 넣음
        Invoke("RemoveFirstPage",2f);
    }
    void RemoveFirstPage(){
        plan.gameObject.SetActive(false);
        activities[0].gameObject.SetActive(false);
        Invoke("ViewSecondActivity",1f);
    }
    void ViewSecondActivity(){
        activities[1].gameObject.SetActive(true);
        activities[1].transform.Find("Illust").GetComponent<Animator>().SetInteger("activity_type",2);
        Invoke("ViewThirdActivity",2f);
    }
    void ViewThirdActivity(){
        activities[2].gameObject.SetActive(true);
        activities[2].transform.Find("Illust").GetComponent<Animator>().SetInteger("activity_type",3);
        Invoke("ActiveNextButton",2f);
    }
    void ActiveNextButton(){
        nextButton.SetActive(true);
    }
    
    
}
