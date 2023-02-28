using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;
    void Awake()
    {
        playerInfoData = Managers.Player.playerInfoData;  
        playerStatData = Managers.Player.playerStatData;
    }
}
