using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestListItem : MonoBehaviour
{
    public TMP_Text text;
    private int id;
    private string name;
    private string img_path;
    public void Init(int id, string name, string img_path){
        this.id=id;
        this.name=name;
        this.img_path=img_path;
        text.text=name;
    }
     public void OnClickItem(){ //Activity Type에 따른 텍스트 업데이트
        //text.text=TypeButton.GetActivityType().ToString();
        Debug.Log(img_path);
        //TODO 실제 리소스 경로로 변경해줘야 함
        if(TestGUI.scheduleCount<3){
            TestGUI.scheduleImageList.Add(img_path);
            //TestGUI.staticCalender[TestGUI.scheduleCount].GetComponent<Image>().sprite=Resources.Load<Sprite>("test/oomoo1") as Sprite;
            TestGUI.scheduleCount=TestGUI.scheduleImageList.Count;
            Debug.Log(TestGUI.scheduleCount);
        }
    }
}
