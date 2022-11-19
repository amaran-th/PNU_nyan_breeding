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
     public void OnClickItem(){ //Practice Type에 따른 텍스트 업데이트
        //text.text=TypeButton.GetPracticeType().ToString();
        Debug.Log(img_path);
    }
}
