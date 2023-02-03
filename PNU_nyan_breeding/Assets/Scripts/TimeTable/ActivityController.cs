using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivityController : MonoBehaviour
{
    public GameObject plan;
    public GameObject firstActivity;
    public GameObject secondActivity;
    public GameObject thirdActivity;
    public static bool trigger;
    void Awake(){
        trigger=false;
    }
    void Update(){
        if(trigger){
            trigger=false;
            Invoke("ViewFirstActivity",1f);
        }
    }

    
    void ViewFirstActivity(){
        trigger=false;
        firstActivity.SetActive(true);
        Invoke("RemoveFirstPage",2f);
    }
    void RemoveFirstPage(){
        plan.gameObject.SetActive(false);
        firstActivity.gameObject.SetActive(false);
        Invoke("ViewSecondActivity",1f);
    }
    void ViewSecondActivity(){
        secondActivity.gameObject.SetActive(true);
        Invoke("ViewThirdActivity",2f);
    }
    void ViewThirdActivity(){
        thirdActivity.gameObject.SetActive(true);
        Invoke("NextScene",2f);
    }

    void NextScene() {
        ShareData.fixedScheduleList=CalenderController.scheduleList;
        SceneManager.LoadScene("MonthlyResultScene");
    }
    public void ViewActivity(){
        Debug.Log("aaa");
        Invoke("ViewFirstActivity",1f);
    }
}
