using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonthlyResultManager : MonoBehaviour
{
    public static List<Activity> fixedScheduleList ;
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;

    public static int[] Diff = new int[7]; 
    public static int[] playerStat = new int[6];

    void Awake()
    {
        playerInfoData = Managers.Player.playerInfoData; 
        playerStatData = Managers.Player.playerStatData;
        fixedScheduleList = ShareData.fixedScheduleList;

        playerStat[0] = playerStatData.coding_stat;
        playerStat[1] = playerStatData.know_stat;
        playerStat[2] = playerStatData.security_stat;
        playerStat[3] = playerStatData.sociality_stat;
        playerStat[4] = playerStatData.interest_stat;
        playerStat[5] = playerStatData.stress_stat;
    }

    void Start()
    {

        for(int i=0;i<3;i++){
            Diff[0] += fixedScheduleList[i].coding_stat;
            Diff[1] += fixedScheduleList[i].know_stat;
            Diff[2] += fixedScheduleList[i].security_stat;
            Diff[3] += fixedScheduleList[i].sociality_stat;
            Diff[4] += fixedScheduleList[i].interest_stat;
            Diff[5] += fixedScheduleList[i].stress_stat;
            Diff[6] += fixedScheduleList[i].money_stat;//
        }    
  
    }

}
