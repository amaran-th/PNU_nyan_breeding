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
    public static Dictionary<int, NPC> npcData;

    public static List<int> Diff; 
    public static int MoneyTotalDiff;
    public static int MoneyMinusDiff;
    public static int MoneyPlusDiff;
    public static int MoneyTemp;

    public static List<int> temp; 
    
    public static List<int> playerStat = new List<int>();
    void Awake()
    {
        fixedScheduleList= ShareData.fixedScheduleList;
        playerInfoData= Managers.Player.playerInfoData;
        playerStatData= Managers.Player.playerStatData;
        npcData=Managers.Data.npcData;
        Diff = new List<int>(){0,0,0,0,0,0,0};
        MoneyMinusDiff=-1000;    //고정지출
        playerStat = playerStatData.GetStatList();

        for(int i=0;i<3;i++){
            temp=fixedScheduleList[i].GetStatList();
            MoneyTemp = fixedScheduleList[i].GetMoney();

            if(MoneyTemp>0){
                MoneyPlusDiff+=MoneyTemp;
            }
            else if(MoneyTemp<0) {
                MoneyMinusDiff+=MoneyTemp;
            }
           
            for(int j=0;j<temp.Count;j++){
                Diff[j]+=temp[j];
            }
        }    

        MoneyTotalDiff = MoneyPlusDiff + MoneyMinusDiff;
    }

}
