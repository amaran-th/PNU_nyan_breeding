using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClickHomeSceneButton()
    {
        MonthlyResultManager.playerStatData.coding_stat += MonthlyResultManager.Diff[0];
        MonthlyResultManager.playerStatData.know_stat   += MonthlyResultManager.Diff[1];
        MonthlyResultManager.playerStatData.security_stat   += MonthlyResultManager.Diff[2];
        MonthlyResultManager.playerStatData.sociality_stat  += MonthlyResultManager.Diff[3];
        MonthlyResultManager.playerStatData.interest_stat   += MonthlyResultManager.Diff[4];
        MonthlyResultManager.playerStatData.stress_stat += MonthlyResultManager.Diff[5];
        MonthlyResultManager.playerInfoData.money_stat  += MonthlyResultManager.Diff[6];
        SceneManager.LoadScene("HomeScene");
    }
}
