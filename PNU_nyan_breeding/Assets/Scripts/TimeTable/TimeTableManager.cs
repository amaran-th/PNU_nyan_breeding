using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTableManager : MonoBehaviour
{
    public static List<Dictionary<int, Activity>> activityDataList;   //DataManager를 통해 로드된 활동 데이터
    public static int grade=3;
    public static int month=12;

    void Awake(){
        //Json 파일로부터 데이터 로드
        activityDataList = Managers.Data.activityDataList;    
    }
    
}
