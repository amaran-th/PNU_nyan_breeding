using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeButton : MonoBehaviour
{
    //열거형
    public enum PracticeType{
        Study, Arbite, Leisure, Club, Competition
    }

    private static PracticeType currentType;

    void Start()
    {
        currentType=PracticeType.Study;
    }

    public static int GetPracticeType(){
        return (int)currentType;
    }

    public void onClickTypeButton(int type){
        currentType=(PracticeType)type; //type 업데이트
        TestGUI.onTypeChange(); //목록 업데이트
        Debug.Log(type);    
    }
}
