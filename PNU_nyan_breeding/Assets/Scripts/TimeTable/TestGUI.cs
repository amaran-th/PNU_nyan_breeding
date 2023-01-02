using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGUI : MonoBehaviour
{
    public RectTransform contents;
    public GameObject listItemGO;
    public GameObject[] calender=new GameObject[3];
    public Button finishButton;


    private List<TestListItem> objectList=new List<TestListItem>();
    private string[] pathList={"Json/activity_study","Json/activity_arbite","Json/activity_leisure","Json/activity_club","Json/activity_competition"};
    
    public static ActivityType currentType = ActivityType.Study;
    ActivityType newType = ActivityType.Study;
    public static int scheduleCount;
    int newCount=0;
    public static GameObject[] staticCalender=new GameObject[3];
    public static List<string> scheduleImageList=new List<string>();
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
    //scheduleCount가 변할 때마다
    public int detectScheduleCount{
        set{
            if (newCount == value) return;
            newCount = value;
            Debug.Log(newCount);
            UpdateCalender();
            UpdateFinishButton();
        }
        get{
            return newCount;
        }
    }
    void Awake(){
        DataManager.Instance.LoadData(pathList);    //Json 파일로부터 데이터 로드
        scheduleCount=0;
        currentType=ActivityType.Study; //초기 활동을 수업듣기로 설정
        for(int i=0;i<3;i++){
            staticCalender[i]=calender[i];
            Debug.Log(staticCalender[i]);
        }
        scheduleCount=0;
    }
    void Start(){
        UpdateItemList(currentType); 
        UpdateCalender(); 
        UpdateFinishButton();  
    }
    void Update(){
        detectType=currentType;
        detectScheduleCount=scheduleCount;
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
    public void UpdateCalender(){
        for(int i=0;i<scheduleCount;i++){
            staticCalender[i].GetComponent<Image>().sprite=Resources.Load<Sprite>(scheduleImageList[i]) as Sprite;
            }
        for(int i=scheduleCount;i<3;i++){
            staticCalender[i].GetComponent<Image>().sprite=Resources.Load<Sprite>("Images/Practice/empty") as Sprite;
        }
    }

    public void UpdateFinishButton(){
        if(scheduleCount==3){
            finishButton.interactable = true;
            ColorBlock colorBlock = finishButton.colors;
	        //(r, g, b, a) 기준 빨간색으로 normal Color 지정
            colorBlock.normalColor = new Color(1f, 0.5467f, 0.0226f, 1f);
            finishButton.colors = colorBlock;
        }else{
            finishButton.interactable = false;
            
        }
    }
    
   
}
