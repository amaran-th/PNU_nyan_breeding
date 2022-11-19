using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour
{
    public RectTransform contents;
    public GameObject listItemGO;
    public GameObject[] Calender=new GameObject[3];
    private static List<TestListItem> objectList=new List<TestListItem>();
    private string[] pathList={"Json/practice_study","Json/practice_arbite","Json/practice_leisure","Json/practice_club","Json/practice_competition"};
    
    public static PracticeType currentType = PracticeType.Study;
    PracticeType CURRENT_EVENT = PracticeType.Study;

    public PracticeType detectType{
        set
        {
            if (CURRENT_EVENT == value) return;

            CURRENT_EVENT = value;

            UpdateItemList(CURRENT_EVENT);
        }
        get
        {
            return CURRENT_EVENT;
        }
    }
    void Awake(){
        //TODO 더 좋은 작성 방법이 있을 것 같다.
        DataManager.Instance.LoadData(pathList);
        currentType=PracticeType.Study;
    }
    void Start(){
        UpdateItemList(currentType);
    }
    void Update(){
        detectType=currentType;
    }

    public void UpdateItemList(PracticeType type){
        var testData=DataManager.Instance.dicTestData[(int)type];
        RemoveItemList();
        for(int i=0;i<testData.Count;i++){
            var data=(PracticeData)testData[i];
            var listItem=Instantiate(listItemGO, contents);
            listItem.transform.SetParent(GameObject.Find("Content").transform);
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
