using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;
    void Awake()
    {
        playerInfoData = Managers.Player.playerInfoData;  
        playerStatData = Managers.Player.playerStatData;  
        Debug.Log(playerInfoData.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
