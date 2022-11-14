using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public Dictionary<int, RawData> dicTestData;
    
    void Awake()
    {
        DataManager.Instance=this;
        this.dicTestData=new Dictionary<int, RawData>();
    }
    public void LoadData(string path)
    {
        var ta=Resources.Load<TextAsset>(path);
        Debug.Log(ta);
        var json=ta.text;
        var arrData=JsonConvert.DeserializeObject<TestData[]>(json);
        foreach(var data in arrData)
        {
            this.dicTestData.Add(data.id, data);
        }
    }
}
