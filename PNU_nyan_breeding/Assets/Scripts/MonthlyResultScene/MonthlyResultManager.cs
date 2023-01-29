using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonthlyResultManager : MonoBehaviour
{
    public static List<Activity> fixedScheduleList= ShareData.fixedScheduleList ;
    public static PlayerInfo playerInfoData= Managers.Player.playerInfoData;
    public static PlayerStat playerStatData= Managers.Player.playerStatData;

    public static List<int> Diff = new List<int>(){0,0,0,0,0,0,0}; 
    public static List<int> temp = new List<int>(); 
    
    public static List<int> playerStat = new List<int>();
    void Awake()
    {
        playerStat = playerStatData.GetStatList();
        for(int i=0;i<3;i++){
            temp=fixedScheduleList[i].GetStatList();
            for(int j=0;j<temp.Count;j++){
                Diff[j]+=temp[j];
            }
        }    
    }

    void Start()
    {

        
  
    }

}
