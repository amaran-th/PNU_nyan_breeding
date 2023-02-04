using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoListController : MonoBehaviour
{
    public RectTransform contents;
    public GameObject listItemGO;
    public TMP_Text categoryName;

    //활동 카테고리
    public static ActivityType currentType = ActivityType.Major;
    ActivityType newType = ActivityType.Major;

    //활동 카테고리가 변할 때마다
    public ActivityType detectType{
        set{
            if (newType == value) return;
            newType = value;
            UpdateItemList(newType);
        }
        get{
            return newType;
        }
    }
    void Awake(){
        currentType=ActivityType.Major; //초기 활동을 [수업듣기]로 설정
    }
    void Start()
    {
        UpdateItemList(currentType); 
    }

    
    void Update()
    {
        detectType=currentType;
    }

    //활동 카테고리가 바뀔 때마다 활동 목록을 새로 Display한다.
    public void UpdateItemList(ActivityType type){
        categoryName.text=ConvertTypeToStr(newType);
        var activityDict=TimeTableManager.activityDataList[(int)type];
        RemoveItemList();
        for(int i=0;i<activityDict.Count;i++){
            var activity=(Activity)activityDict[i];
            if(activity.grade!=0&&!(activity.grade==TimeTableManager.grade||activity.grade==-TimeTableManager.month)) continue;
            var listItem=Instantiate(listItemGO, contents); //자식 객체 생성
            listItem.transform.SetParent(GameObject.Find("Content").transform); //위치 설정
            var testListItem=listItem.GetComponent<TestListItem>();
            testListItem.Init(activity);
            Debug.Log(activity.name);
            //transform.SetParent(GameObject.Find("Content").transform);
        
        }
    }
    string ConvertTypeToStr(ActivityType type){
        if(type==ActivityType.Major) return "전공 수업";
        if(type==ActivityType.Culture) return "교양 수업";
        if(type==ActivityType.Club) return "동아리";
        if(type==ActivityType.Leisure) return "여가 활동";
        if(type==ActivityType.Arbite) return "알바";
        return "이벤트";
    }
    public void RemoveItemList(){
        Transform[] oldItemList = GameObject.Find("Content").GetComponentsInChildren<Transform>();

        if (oldItemList != null) {
            for (int i = 1; i < oldItemList.Length; i++) {
                if (oldItemList[i] != transform)
                    Destroy(oldItemList[i].gameObject);
            }
        }
    }

}
