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

    public static List<int> Diff = new List<int>(){0,0,0,0,0,0,0}; 
    public static List<int> temp = new List<int>(); 
    
    public static List<int> playerStat = new List<int>();
    void Awake()
    {
        playerInfoData = Managers.Player.playerInfoData; 
        playerStatData = Managers.Player.playerStatData;
        fixedScheduleList = ShareData.fixedScheduleList;

        playerStat = playerStatData.GetStatList();
 
    }

    void Start()
    {

        for(int i=0;i<3;i++){
            temp=fixedScheduleList[i].GetStatList();
            for(int j=0;j<temp.Count;j++){
                Diff[j]+=temp[j];
            }
        }    
  
    }

}
