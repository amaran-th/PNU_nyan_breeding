using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public List<Dictionary<int, RawData>> dicTestData;
    
    void Awake()
    {
        DataManager.Instance=this;
        this.dicTestData=new List<Dictionary<int, RawData>>();
    }
    public void LoadData(string[] path)
    {   
        for(int i=0;i<path.Length;i++){
            var ta=Resources.Load<TextAsset>(path[i]);
            Debug.Log(ta);
            var json=ta.text;
            var arrData=JsonConvert.DeserializeObject<PracticeData[]>(json);
            Dictionary<int,RawData> dicData=new Dictionary<int,RawData>();
            foreach(var data in arrData)
            {
                dicData.Add(data.id, data);
            }
            this.dicTestData.Add(dicData);
        }
        
    }
}
