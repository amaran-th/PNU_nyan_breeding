using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CalculateEnding : MonoBehaviour
{
    int CodingStat;
    int KnowStat;
    int SecurityStat;
    int SocialityStat;
    int InterestStat;
    int StressStat;

    void Start()
    {
        CodingStat = EndingManager.playerStatData.coding_stat;
        KnowStat = EndingManager.playerStatData.know_stat;
        SecurityStat = EndingManager.playerStatData.security_stat;
        SocialityStat = EndingManager.playerStatData.sociality_stat;
        InterestStat = EndingManager.playerStatData.interest_stat;
        StressStat = EndingManager.playerStatData.stress_stat;
        
        if(CodingStat>80 || KnowStat>80 || SecurityStat>80) Debug.Log("대학원");
        else if(CodingStat>65 || KnowStat>65 || SecurityStat>65) Debug.Log("개발자");
        else Debug.Log("백수");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
