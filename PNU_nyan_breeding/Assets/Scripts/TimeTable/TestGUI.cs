using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour
{
    public RectTransform contents;
    public GameObject listItemGO;
    // Start is called before the first frame update
    void Start()
    {
        
        DataManager.Instance.LoadData("Data/test_data");
        var testData=DataManager.Instance.dicTestData;
        for(int i=0;i<testData.Count;i++){
            var data=(TestData)testData[i];
            var listItem=Instantiate(listItemGO, contents);
            listItem.transform.SetParent(GameObject.Find("Content").transform);
            var testListItem=listItem.GetComponent<TestListItem>();
            testListItem.Init(data.id, data.ico_name);
            Debug.Log(data.ico_name);
            //transform.SetParent(GameObject.Find("Content").transform);
        
        }
    }

   
}
