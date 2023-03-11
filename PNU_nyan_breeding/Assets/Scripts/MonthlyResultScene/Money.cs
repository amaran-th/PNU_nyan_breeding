using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TMP_Text origin;
    public TMP_Text plusDiff;
    public TMP_Text minusDiff;
    public TMP_Text totalDiff;
    public TMP_Text result;
    
    void Start()
    {
        origin.text = MonthlyResultManager.playerInfoData.money_stat+"냥";
        plusDiff.text="+"+MonthlyResultManager.MoneyPlusDiff;
        minusDiff.text = "" + MonthlyResultManager.MoneyMinusDiff;
        plusDiff.color =  new Color32(36,125,255,255); 
        minusDiff.color =  new Color32(255,80,51,255);

        if (MonthlyResultManager.MoneyTotalDiff>0) {
            totalDiff.text="+"+MonthlyResultManager.MoneyTotalDiff+"냥";
        }
        else if (MonthlyResultManager.MoneyTotalDiff==0) {
            totalDiff.text="변동없음";
        }
        else if (MonthlyResultManager.MoneyTotalDiff<0) {
            totalDiff.text=""+MonthlyResultManager.MoneyTotalDiff+"냥";
        }
     
        
        result.text = MonthlyResultManager.playerInfoData.money_stat + MonthlyResultManager.MoneyTotalDiff+"냥";
    }

}
