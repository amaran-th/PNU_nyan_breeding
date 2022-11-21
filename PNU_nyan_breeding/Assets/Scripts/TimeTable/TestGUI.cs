using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour
{
    public RectTransform contents;
    public GameObject listItemGO;
    public GameObject[] Calender=new GameObject[3];


    private List<TestListItem> objectList=new List<TestListItem>();
    private string[] pathList={"Json/activity_study","Json/activity_arbite","Json/activity_leisure","Json/activity_club","Json/activity_competition"};
    
    public static ActivityType currentType = ActivityType.Study;
    ActivityType newType = ActivityType.Study;

    //activity type이 변할 때마다
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
        DataManager.Instance.LoadData(pathList);    //Json 파일로부터 데이터 로드
        currentType=ActivityType.Study; //초기 활동을 수업듣기로 설정
    }
    void Start(){
        UpdateItemList(currentType);    
    }
    void Update(){
        detectType=currentType;
    }

    public void UpdateItemList(ActivityType type){
        var testData=DataManager.Instance.dicTestData[(int)type];
        RemoveItemList();
        for(int i=0;i<testData.Count;i++){
            var data=(ActivityData)testData[i];
            var listItem=Instantiate(listItemGO, contents); //자식 객체 생성
            listItem.transform.SetParent(GameObject.Find("Content").transform); //위치 설정
            var testListItem=listItem.GetComponent<TestListItem>();
            objectList.Add(testListItem);
            testListItem.Init(data.id, data.name,data.img_path);
            Debug.Log(data.name);
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
