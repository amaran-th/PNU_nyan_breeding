using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    public TMP_Text text;
    void Awake()
    {
        text.text=MonthlyResultManager.playerInfoData.grade+"학년"+MonthlyResultManager.playerInfoData.month+"월 월말정산";
    }
}
