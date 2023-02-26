using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class EndingCollectionManager : MonoBehaviour
{
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;
    public static Ending endingData;

    public static List<int> playerStat = new List<int>();

    void Awake()
    {
        //Json 파일로부터 데이터 로드
        playerInfoData = Managers.Player.playerInfoData;  
        playerStatData = Managers.Player.playerStatData;  
        playerStat = playerStatData.GetStatList();
        endingData = Managers.Player.endingData;     
    }

    
}
