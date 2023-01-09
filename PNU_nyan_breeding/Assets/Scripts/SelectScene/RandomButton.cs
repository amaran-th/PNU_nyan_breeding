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
    }

    public string GetRandomName(Dictionary<int, RandomName> nameList){
        return  nameList[Random.Range(0,nameList.Count)].name;
    }
    public void OnClickRandomButton(){
        inputField.text=GetRandomName(SelectManager.randomNameData);
    }
}
