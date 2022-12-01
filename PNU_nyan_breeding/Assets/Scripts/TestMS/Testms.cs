using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class Testms : MonoBehaviour
{
    public GameObject buttonMS;
    public TextAsset test_data;

    public void ChangeColorAndPrint() 
    {
        buttonMS.GetComponent<Image>().color = Color.red;
        Debug.Log("Button Clicked");

        // json 파일을 클래스 객체로 파싱
        var data = JsonConvert.DeserializeObject<TestClass[]>(test_data.text);
        foreach (var d in data)
        {
            //Debug.Log($"id: {i.id}, ico_name: {i.ico_name}, name: {i.name}");
            Debug.Log($"ico_name: {d.ico_name}");
        }
    }
}
