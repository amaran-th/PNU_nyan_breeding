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

    public static Dictionary<int,EndingDialogue> dialogueList = new Dictionary<int,EndingDialogue>();
    public static Dictionary<int,EndingDialogue> employmentEnd = new Dictionary<int,EndingDialogue>();
    public static Dictionary<int,EndingDialogue> joblessEnd = new Dictionary<int,EndingDialogue>();
    public static Dictionary<int,EndingDialogue> graduateSchoolEnd = new Dictionary<int,EndingDialogue>();
    public Dictionary<int,EndingDialogue>[] endingName = new Dictionary<int,EndingDialogue>[3];
    public Dictionary<int,EndingDialogue> resEnding = new Dictionary<int,EndingDialogue>();
    public Dictionary<int, EndingIllust> illustList =new Dictionary<int, EndingIllust>(); 

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
        else EndingIndex=2;

        Debug.Log(EndingIndex);
        
        DeclareEnding();
        DeclareIllust();
    }

    void DeclareEnding(){
        employmentEnd = Managers.Data.employmentEnd;
        joblessEnd = Managers.Data.joblessEnd;
        graduateSchoolEnd = Managers.Data.graduateSchoolEnd;
        illustList = Managers.Data.illustList;

        endingName[0]=employmentEnd;
        endingName[1]=joblessEnd;
        endingName[2]=graduateSchoolEnd;

        resEnding = endingName[EndingIndex];
        Debug.Log(resEnding[0]);
    }

    // Update is called once per frame
    void DeclareIllust() {
        Debug.Log(illustList[EndingIndex].img_path);
        endingIllust.sprite = Resources.Load<Sprite>(illustList[EndingIndex].img_path);
    }
}
