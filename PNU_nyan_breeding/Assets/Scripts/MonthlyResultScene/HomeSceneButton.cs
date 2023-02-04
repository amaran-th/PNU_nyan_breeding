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
        MonthlyResultManager.playerInfoData.UpdateInfo(MonthlyResultManager.MoneyDiff,ShareData.selectedNPCId);
        ShareData.fixedScheduleList=new List<Activity>();
        ShareData.selectedNPCId=-1;
        SceneManager.LoadScene("HomeScene");
    }
}
