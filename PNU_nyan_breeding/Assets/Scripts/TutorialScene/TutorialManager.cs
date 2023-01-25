using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;
 
    void Awake()
    {
        playerInfoData = Managers.Player.playerInfoData;  
        playerStatData = Managers.Player.playerStatData;  
        
    }

    void Start()
    {
        ModalManager.instance.OpenModal("1번째 튜토리얼입니다~",  YesOrNoButton );  
    }

    public void YesOrNoButton()
    {
         ModalManager.instance.YesOrNoOpenModal("치킨집 장사를 하시겠습니까?",YesButton,NoButton);  
    }

    public void YesButton()
    {
        Debug.Log("네");
    }

    public void NoButton()
    {
        Debug.Log("아니오"); 
    }
}
