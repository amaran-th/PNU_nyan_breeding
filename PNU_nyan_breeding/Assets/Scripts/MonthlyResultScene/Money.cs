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
        origin.text = MonthlyResultManager.playerInfoData.money_stat+"원";
        if(MonthlyResultManager.MoneyDiff>0){
            differ.color=new Color(0.4666667f,0.6455813f,0.7843137f,1f);
            differ.text="+";
        }else if(MonthlyResultManager.MoneyDiff<0){
            differ.color=new Color(1f, 0.5026245f, 0.4283019f, 1f);
        }else{
            differ.text="0";
        }
        differ.text += MonthlyResultManager.MoneyDiff+"원";
        result.text = MonthlyResultManager.playerInfoData.money_stat + MonthlyResultManager.MoneyDiff+"원";
    }

}
