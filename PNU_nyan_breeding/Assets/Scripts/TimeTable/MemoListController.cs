using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoListController : MonoBehaviour
{
    public RectTransform contents;
    public GameObject listItemGO;

    //활동 카테고리
    public static ActivityType currentType = ActivityType.Study;
    ActivityType newType = ActivityType.Study;

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
        currentType=ActivityType.Study; //초기 활동을 [수업듣기]로 설정
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
        var activityDict=TimeTableManager.activityDataList[(int)type];
        RemoveItemList();
        for(int i=0;i<activityDict.Count;i++){
            var activity=(Activity)activityDict[i];
            var listItem=Instantiate(listItemGO, contents); //자식 객체 생성
            listItem.transform.SetParent(GameObject.Find("Content").transform); //위치 설정
            var testListItem=listItem.GetComponent<TestListItem>();
            testListItem.Init(activity);
            Debug.Log(activity.name);
            //transform.SetParent(GameObject.Find("Content").transform);
        
        }
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
