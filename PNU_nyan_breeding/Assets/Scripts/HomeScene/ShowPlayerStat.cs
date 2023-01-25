using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPlayerStat : MonoBehaviour
{
    public Slider CodingStat;
    public Slider KnowStat;
    public Slider SecurityStat;
    public Slider SocialityStat;
    public Slider InterestStat;
    public Slider StressStat;



    void Start()
    {
 
        CodingStat.value = HomeManager.playerStatData.coding_stat;
        KnowStat.value = HomeManager.playerStatData.know_stat;
        SecurityStat.value = HomeManager.playerStatData.security_stat;
        SocialityStat.value = HomeManager.playerStatData.sociality_stat;
        InterestStat.value = HomeManager.playerStatData.interest_stat;
        StressStat.value = HomeManager.playerStatData.stress_stat;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
