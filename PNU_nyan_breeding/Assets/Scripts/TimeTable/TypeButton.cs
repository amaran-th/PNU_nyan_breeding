using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeButton : MonoBehaviour
{   
    public int type;
    public Button button;
    public void Update(){
        button.image.color=((int)TestGUI.currentType==type)?Color.yellow:Color.white;
    }
    public void OnClickTypeButton(){
        TestGUI.currentType=(ActivityType)type; //type 업데이트
        
        //testGUI.onTypeChange(); //목록 업데이트
        Debug.Log(type);    
    }
}
