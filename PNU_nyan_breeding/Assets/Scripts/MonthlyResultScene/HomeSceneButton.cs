using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneButton : MonoBehaviour
{
 
    public void OnClickHomeSceneButton()
    {
        MonthlyResultManager.playerStatData.UpdateStat(MonthlyResultManager.Diff);
        //===========================
        MonthlyResultManager.playerInfoData.UpdateInfo(MonthlyResultManager.Diff[6]);
        ShareData.fixedScheduleList=new List<Activity>();
        SceneManager.LoadScene("HomeScene");
    }
}
