using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

public class RandomButton : MonoBehaviour
{
    public TMP_InputField inputField;
    
    void Awake(){ 
        LoadRandomNameList();
    }

    public string GetRandomName(List<string> nameList){
        return nameList[Random.Range(0,nameList.Count)];
    }
    public void OnClickRandomButton(){
        Debug.Log("click");
        inputField.text=GetRandomName(randomNameList);
    }

    
    //TODO selectManager에서 data불러오게!!

    //랜덤 이름을 저장할 리스트
    public static List<string> randomNameList=new List<string>();   ////

    void LoadRandomNameList(){  ////
        var ta=Resources.Load<TextAsset>("Json/test_data");
        var json=ta.text;
        var arrData=JsonConvert.DeserializeObject<NameData[]>(json);
        foreach(var data in arrData)
        {
            randomNameList.Add(data.name);
        }
    }
}
