using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventList : MonoBehaviour
{

    public int eventIndex;
    public Image backgroundImg;

    public Dictionary<int, Background> backgroundList =new Dictionary<int, Background>(); 
    
    public static int[] npc_story_count;
    public static List<Dictionary<int, ProfessorEvent>> professorEventList;
    public static List<Dictionary<int, ProfessorEvent>> blackCatEventList; 
    public static List<Dictionary<int, ProfessorEvent>> butlerEventList;
    public static List<Dictionary<int, ProfessorEvent>> presidentEventList;
    public Dictionary<int, ProfessorEvent> resEvent;
    public int resNpcId;
    public int resNpcCount;

    void Awake() {

        Debug.Log("EventList");
        backgroundList = Managers.Data.backgroundList;
        npc_story_count=Managers.Player.playerInfoData.npc_story_count;
        professorEventList = Managers.Data.professorEvent;
        blackCatEventList = Managers.Data.blackCatEvent;
        butlerEventList = Managers.Data.butlerEvent;
        presidentEventList = Managers.Data.presidentEvent;

        resNpcId = ShareData.selectedNPCId;
        resNpcCount=npc_story_count[resNpcId];
        switch (resNpcId)
        {
            case 0: 
                resEvent = professorEventList[resNpcCount];
                break;
            case 1: 
                resEvent = blackCatEventList[resNpcCount];
                break;
            case 2:
                resEvent = butlerEventList[resNpcCount];
                break;
            case 3:
                resEvent = presidentEventList[resNpcCount];
                break;
            default: break;
        }
        DeclareIllust();
    }

    // Update is called once per frame
    void DeclareIllust() {
        Debug.Log(backgroundList[eventIndex].img_path);
        backgroundImg.sprite = Resources.Load<Sprite>(backgroundList[eventIndex].img_path);
    }
}
