using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTableManager : MonoBehaviour
{
    public static List<Dictionary<int, Activity>> activityDataList;   //DataManager를 통해 로드된 활동 데이터
    public static int grade=Managers.Player.playerInfoData.grade;
    public static int month=Managers.Player.playerInfoData.month;
    public static int curMoney=Managers.Player.playerInfoData.money_stat;
    public static int selectedMoney=0;
    public static GameObject tooltip;
    public GameObject shareData;

    void Awake(){
        //Json 파일로부터 데이터 로드
        activityDataList = Managers.Data.activityDataList;
        DontDestroyOnLoad(shareData);  
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }
    
}
