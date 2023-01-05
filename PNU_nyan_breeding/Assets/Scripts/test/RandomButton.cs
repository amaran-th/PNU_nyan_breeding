using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomButton : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetRandomName(List<string> nameList){
        return nameList[Random.Range(0,nameList.Count)];
    }
    public void OnClickRandomButton(){
        Debug.Log("click");
        inputField.text=GetRandomName(RandomDataManager.randomNameList);
    }
}
