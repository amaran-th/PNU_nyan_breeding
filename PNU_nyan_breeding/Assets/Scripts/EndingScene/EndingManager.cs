using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;
    public static List<Dictionary<int, EndingDialogue>> normalEnding;
    public static List<Dictionary<int, EndingDialogue>> badEnding;
    public static List<Dictionary<int, EndingDialogue>> hiddenEnding;
    void Awake()
    {
        playerInfoData = Managers.Player.playerInfoData;  
        playerStatData = Managers.Player.playerStatData;
        normalEnding = Managers.Data.normalEnding;
        badEnding = Managers.Data.badEnding;
        hiddenEnding = Managers.Data.hiddenEnding;
    }
}
