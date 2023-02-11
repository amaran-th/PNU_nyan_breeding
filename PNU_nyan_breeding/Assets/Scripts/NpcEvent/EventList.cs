using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventList : MonoBehaviour
{

    public int eventIndex;
    public Image backgroundImg;

    public Dictionary<int, TempEvent> tempEvent =new Dictionary<int, TempEvent>();
    public Dictionary<int,TempEvent>[] EventName = new Dictionary<int,TempEvent>[3];
    public Dictionary<int,TempEvent> resEvent = new Dictionary<int,TempEvent>();
    public Dictionary<int, Background> backgroundList =new Dictionary<int, Background>(); 
    

    void Awake() {

        eventIndex = 0;

        Debug.Log("EventList");
        backgroundList = Managers.Data.backgroundList;
        DeclareEvent();
        DeclareIllust();
    }

     void DeclareEvent()
    {
        tempEvent = Managers.Data.tempEvent;
        EventName[0]=tempEvent;
        EventName[1] = tempEvent;
        EventName[2] = tempEvent;

        resEvent = EventName[eventIndex];
        Debug.Log(resEvent[0]);
    }

    // Update is called once per frame
    void DeclareIllust() {
        Debug.Log(backgroundList[eventIndex].img_path);
        backgroundImg.sprite = Resources.Load<Sprite>(backgroundList[eventIndex].img_path);
    }
}
