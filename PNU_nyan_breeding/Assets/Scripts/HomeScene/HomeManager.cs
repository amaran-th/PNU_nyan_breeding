using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;

    public static List<int> playerStat = new List<int>();
    public static Dictionary<int, NPC> npcData;

    void Awake()
    {
        playerInfoData = Managers.Player.playerInfoData;  
        playerStatData = Managers.Player.playerStatData;  
        playerStat = playerStatData.GetStatList();
        npcData = Managers.Data.npcData;  
    }
}
