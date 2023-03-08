using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CalculateEnding : MonoBehaviour
{
    int CodingStat;
    int KnowStat;
    int SecurityStat;
    int SocialityStat;
    int InterestStat;
    int StressStat;
    public int NormalEndingIndex;
    
    public Image endingIllust;
    public static List<Dictionary<int, EndingDialogue>> normalEnding;
    
    void Awake() {
        Debug.Log("CalculateEnding");
        normalEnding = EndingManager.normalEnding;
        Calculate();
    }

     void Calculate()
    {
        CodingStat = EndingManager.playerStatData.coding_stat;
        KnowStat = EndingManager.playerStatData.know_stat;
        SecurityStat = EndingManager.playerStatData.security_stat;
        SocialityStat = EndingManager.playerStatData.sociality_stat;
        InterestStat = EndingManager.playerStatData.interest_stat;
        StressStat = EndingManager.playerStatData.stress_stat;
        
        if(CodingStat>80 || KnowStat>80 || SecurityStat>80) NormalEndingIndex=0;
        else if(CodingStat>65 || KnowStat>65 || SecurityStat>65) NormalEndingIndex=1;
        else NormalEndingIndex=0;

        Debug.Log(NormalEndingIndex);
        ShareData.EndingIndex = NormalEndingIndex;
        ShareData.resEnding = normalEnding[ShareData.EndingIndex];
    }
}
