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
    public static List<Dictionary<int, EndingDialogue>> badEnding;
    public static List<Dictionary<int, EndingDialogue>> hiddenEnding;
    
    void Awake() {
        normalEnding = Managers.Data.normalEnding;
        badEnding = EndingManager.badEnding;
        hiddenEnding = EndingManager.hiddenEnding;
        Debug.Log("whichEnding?: "+ShareData.whichEnding[0]+ShareData.whichEnding[1]+ShareData.whichEnding[2]);
        if(ShareData.whichEnding[0]) {normalEnd(); return;};
        if(ShareData.whichEnding[1]) {badEnd(); return;};
        if(ShareData.whichEnding[2]) {hiddenEnd(); return;};
    }

     void normalEnd()
    {
        CodingStat = EndingManager.playerStatData.coding_stat;
        KnowStat = EndingManager.playerStatData.know_stat;
        SecurityStat = EndingManager.playerStatData.security_stat;
        SocialityStat = EndingManager.playerStatData.sociality_stat;
        InterestStat = EndingManager.playerStatData.interest_stat;
        StressStat = EndingManager.playerStatData.stress_stat;
        
        if(CodingStat>80 || KnowStat>80 || SecurityStat>80) NormalEndingIndex=0;
        else if(CodingStat>65 || KnowStat>65 || SecurityStat>65) NormalEndingIndex=1;
        else NormalEndingIndex=1;

        Debug.Log(NormalEndingIndex);
        ShareData.endingIndex = NormalEndingIndex;
        ShareData.resEnding = normalEnding[ShareData.endingIndex];
        Debug.Log("Ending[0]: "+ShareData.resEnding[0].background);
    }

    void badEnd()
    {
        ShareData.resEnding = badEnding[ShareData.endingIndex];
    }
    void hiddenEnd()
    {
        ShareData.resEnding = hiddenEnding[ShareData.endingIndex];
    }
}
