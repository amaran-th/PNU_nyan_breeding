using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class RandomDataManager : MonoBehaviour
{
    public static List<string> randomNameList=new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        LoadRandomNameList();
        Debug.Log(randomNameList.Count);
        
    }
    void LoadRandomNameList(){
        var ta=Resources.Load<TextAsset>("Json/test_data");
        Debug.Log(ta);
        var json=ta.text;
        var arrData=JsonConvert.DeserializeObject<NameData[]>(json);
        foreach(var data in arrData)
        {
            randomNameList.Add(data.name);
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
