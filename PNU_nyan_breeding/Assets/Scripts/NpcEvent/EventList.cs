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

    public static List<Dictionary<int, ProfessorEvent>> professorEventList;
    public static List<Dictionary<int, ProfessorEvent>> blackCatEventList; 
    public static List<Dictionary<int, ProfessorEvent>> butlerEventList;
    public static List<Dictionary<int, ProfessorEvent>> presidentEventList;
    public Dictionary<int, ProfessorEvent> resEvent;
    

    void Awake() {

        Debug.Log("EventList");
        backgroundList = Managers.Data.backgroundList;

        professorEventList = Managers.Data.professorEvent;
        blackCatEventList = Managers.Data.blackCatEvent;
        butlerEventList = Managers.Data.butlerEvent;
        presidentEventList = Managers.Data.presidentEvent;

        var npcId = ShareData.selectedNPCId;
        switch (npcId)
        {
            case 0: 
                resEvent = professorEventList[Managers.Player.playerInfoData.profEventCount];
                break;
            case 1: 
                resEvent = blackCatEventList[Managers.Player.playerInfoData.blackCatEventCount];
                break;
            case 2:
                resEvent = butlerEventList[Managers.Player.playerInfoData.butlerEventCount];
                break;
            case 3:
                resEvent = presidentEventList[Managers.Player.playerInfoData.presidentEventCount];
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
