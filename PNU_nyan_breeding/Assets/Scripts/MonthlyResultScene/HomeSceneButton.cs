using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneButton : MonoBehaviour
{
    public GameObject HomeButton;
    void Start()
    {
        if(MonthlyResultManager.playerStatData.stress_stat>=95) 
        {
            HomeButton.SetActive(false);
        }
        else
        {
           HomeButton.SetActive(true);
        }
        Debug.Log(MonthlyResultManager.playerStatData.stress_stat);
    }
 
    public void OnClickHomeSceneButton()
    {
        MonthlyResultManager.playerStatData.UpdateStat(MonthlyResultManager.Diff);
        //===========================
        MonthlyResultManager.playerInfoData.UpdateInfo(MonthlyResultManager.MoneyDiff);
        
        //메일 발송 여부 결정하는 코드
        var npcId=ShareData.selectedNPCId;
        if(npcId!=-1&&npcId<3){
            if(MonthlyResultManager.playerInfoData.npc_bond[npcId]==5&&MonthlyResultManager.playerInfoData.npc_story_count[npcId]==9){
                ShareData.npcMail[npcId]=true;
            }
        }
        //ShareData 초기화
        ShareData.fixedScheduleList=new List<Activity>();
        ShareData.selectedNPCId=-1;
        if(CheckHiddenEnding()) SceneManager.LoadScene("EndingScene");
        else SceneManager.LoadScene("HomeScene");
    }
    bool CheckHiddenEnding(){
        if(Managers.Player.playerInfoData.money_stat<0){
            //길냥이 엔딩 TOENDING
            return true;
        }
        return false;
    }
}
