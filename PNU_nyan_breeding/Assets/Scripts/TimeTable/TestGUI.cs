using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour
{
    public RectTransform contents;
    public GameObject listItemGO;
    public GameObject[] Calender=new GameObject[3];
    private static List<TestListItem> objectList=new List<TestListItem>();

    void Start(){
        
        DataManager.Instance.LoadData("Json/test_data");
        var testData=DataManager.Instance.dicTestData;
        for(int i=0;i<testData.Count;i++){
            var data=(TestData)testData[i];
            var listItem=Instantiate(listItemGO, contents);
            listItem.transform.SetParent(GameObject.Find("Content").transform);
            var testListItem=listItem.GetComponent<TestListItem>();
            objectList.Add(testListItem);
            testListItem.Init(data.id, data.ico_name);
            Debug.Log(data.ico_name);
            //transform.SetParent(GameObject.Find("Content").transform);
        
        }
    }
    public static void onTypeChange(){  //목록 업데이트
        for(int i=0;i<objectList.Count;i++){
            objectList[i].SetType();
        }
    }

   
}
