using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeButton : MonoBehaviour
{
    

    public void onClickTypeButton(int type){
        TestGUI.currentType=(PracticeType)type; //type 업데이트
        //testGUI.onTypeChange(); //목록 업데이트
        Debug.Log(type);    
    }
}
