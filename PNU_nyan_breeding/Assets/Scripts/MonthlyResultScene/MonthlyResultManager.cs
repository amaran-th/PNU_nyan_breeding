using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonthlyResultManager : MonoBehaviour
{
    public static List<Activity> fixedScheduleList;
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;

    public static List<int> Diff; 
    public static List<int> temp; 
    
    public static List<int> playerStat = new List<int>();
    void Awake()
    {
        fixedScheduleList= ShareData.fixedScheduleList;
        playerInfoData= Managers.Player.playerInfoData;
        playerStatData= Managers.Player.playerStatData;
        Diff = new List<int>(){0,0,0,0,0,0,0};
        playerStat = playerStatData.GetStatList();
        for(int i=0;i<3;i++){
            temp=fixedScheduleList[i].GetStatList();
            for(int j=0;j<temp.Count;j++){
                Diff[j]+=temp[j];
            }
        }    
    }

}
