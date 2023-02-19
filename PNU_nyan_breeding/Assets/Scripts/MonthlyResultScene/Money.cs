using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TMP_Text origin;
    public TMP_Text differ;
    public TMP_Text result;
    
    void Start()
    {
        origin.text = MonthlyResultManager.playerInfoData.money_stat+"냥";
        if(MonthlyResultManager.MoneyDiff>0){
            differ.text="<color=blue>+"+MonthlyResultManager.MoneyDiff+"냥</color>";
        }else if(MonthlyResultManager.MoneyDiff<0){
            differ.text="<color=red>"+MonthlyResultManager.MoneyDiff+"냥</color>";
        }else{
            differ.text="0냥";
        }
        result.text = MonthlyResultManager.playerInfoData.money_stat + MonthlyResultManager.MoneyDiff+"냥";
    }

}
