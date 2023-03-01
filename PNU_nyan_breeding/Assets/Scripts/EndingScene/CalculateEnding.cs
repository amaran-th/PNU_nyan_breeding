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
    public int EndingIndex;
    
    public Image endingIllust;

    public static List<Dictionary<int, EndingDialogue>> normalEnding;
    public static List<Dictionary<int, EndingDialogue>> badEnding;
    public static List<Dictionary<int, EndingDialogue>> hiddenEnding; //temp
    public Dictionary<int,EndingDialogue> resEnding = new Dictionary<int,EndingDialogue>();
    
    void Awake() {
        Debug.Log("CalculateEnding");
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
        
        if(CodingStat>80 || KnowStat>80 || SecurityStat>80) EndingIndex=0;
        else if(CodingStat>65 || KnowStat>65 || SecurityStat>65) EndingIndex=1;
        else EndingIndex=0;

        Debug.Log(EndingIndex);
        
        DeclareEnding();
    }

    void DeclareEnding(){
        normalEnding = EndingManager.normalEnding;
        badEnding = EndingManager.badEnding;
        hiddenEnding = EndingManager.hiddenEnding; //temp

        resEnding = hiddenEnding[EndingIndex];  
        Debug.Log(resEnding[0]);
    }

}
