using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalenderController : MonoBehaviour
{
    public GameObject[] calender=new GameObject[3];
    
    //캘린더
    public static int scheduleCount;
    int newCount=0;
    public static List<Activity> scheduleList;

    //캘린더의 크기(선택된 활동 개수) 변할 때마다
    public int detectScheduleCount{
        set{
            if (newCount == value) return;
            newCount = value;
            Debug.Log(newCount);
            UpdateCalender();
        }
        get{
            return newCount;
        }
    }
    void Awake(){
        scheduleCount=0;
        scheduleList=new List<Activity>();
    }

    void Start(){ 
        UpdateCalender();
    }
    void Update(){
        detectScheduleCount=scheduleCount;
    }

    //활동을 추가/제거할 때마다 선택된 일정들을 새로 Display한다.
    public void UpdateCalender(){
        for(int i=0;i<scheduleCount;i++){
            calender[i].GetComponent<Image>().sprite=Resources.Load<Sprite>(scheduleList[i].img_path) as Sprite;
            calender[i].transform.Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text=scheduleList[i].name;
            }
        
        for(int i=scheduleCount;i<3;i++){
            calender[i].GetComponent<Image>().sprite=Resources.Load<Sprite>("Images/Practice/todo_empty") as Sprite;
            calender[i].transform.Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text="";
        }
    }
}
