using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NpcEvent : MonoBehaviour
{
    public GameObject selectUi;
    public TextMeshProUGUI select1;
    public TextMeshProUGUI select2;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textComponent2;
    public GameObject DialogueBox;
    public GameObject StaindingImg;
    public GameObject NameSlot;
    public float textSpeed;
    public Image standingImg;
    public Image backgroundImg;

    private int index = 0;
    private int index2=0;
    private bool preventClick = false;

    public Dictionary<string, int> staindingId = new Dictionary<string, int>()
    {
      {"교수님", 0 },
      {"깜냥이", 1 },
      {"나레이션", 2}
    };
    public static Dictionary<int, Standing> standingList = new Dictionary<int, Standing>();
    public static List<Dictionary<int, ProfessorEvent>> professorEventList;
    public static List<Dictionary<int, ProfessorEvent>> blackCatEventList; 
    public static List<Dictionary<int, ProfessorEvent>> butlerEventList;
    public static List<Dictionary<int, ProfessorEvent>> presidentEventList;
    //public static List<Dictionary<int, ProfessorEvent>>[] npcEventList = {professorEventList,blackCatEventList,butlerEventList,presidentEventList}; //왜 안됨?ㅋㅋ
    public Dictionary<int, ProfessorEvent> resEvent;
    public int resNpcId;

    void Awake() {
        
        selectUi.SetActive(false);
        DialogueBox.SetActive(true);
        standingList = Managers.Data.standingList;
        DeclareEvent();
    }

    void DeclareEvent() {
        Debug.Log("DeclareEvent");

        professorEventList = Managers.Data.professorEvent;
        blackCatEventList = Managers.Data.blackCatEvent;
        butlerEventList = Managers.Data.butlerEvent;
        presidentEventList = Managers.Data.presidentEvent;

        resNpcId = ShareData.selectedNPCId;
        //resNpcId = 1; //개발용 temp
        switch (resNpcId) {
            case 0: resEvent = professorEventList[Managers.Player.playerInfoData.npc_story_count[0]];
                    //resEvent = professorEventList[0]; // 개발용 temp
                    break;
            case 1: resEvent = blackCatEventList[Managers.Player.playerInfoData.npc_story_count[1]];
                    //resEvent = blackCatEventList[0]; // 개발용 temp
                    break;
            case 2: resEvent = butlerEventList[Managers.Player.playerInfoData.npc_story_count[2]];
                    //resEvent = butlerEventList[0]; // 개발용 temp
                    break;
            case 3: resEvent = presidentEventList[Managers.Player.playerInfoData.npc_story_count[3]];
                    //resEvent = presidentEventList[0]; // 개발용 temp
                    break;
        }
        //resEvent = npcEvent[Managers.Player.playerInfoData.npc_story_count[0]];
        Debug.Log("스토리:"+Managers.Player.playerInfoData.npc_story_count[resNpcId]);
        DeclareIllust();
    }

    void DeclareIllust() {
        Debug.Log(resEvent[index].background);
        backgroundImg.sprite = Resources.Load<Sprite>(resEvent[index].background);
    }

    void setIndex2() {
        while(resEvent[index2].name != "선택지2") index2++;
    }

    void Start()
    {
        Debug.Log("NpcEvent");
        textComponent.text = string.Empty;
        textComponent2.text = string.Empty;
        setIndex2();
        NextLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && !preventClick)
        {
            Debug.Log(resEvent[index].script);
            Debug.Log("event count: "+resEvent.Count+" index: "+index);
            if (textComponent.text == resEvent[index].script)
            {
                
                index++;
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = resEvent[index].script;

            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in resEvent[index].script.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        Debug.Log("event count: "+resEvent.Count+" index: "+index);
        if(index <= resEvent.Count && resEvent[index].name != "end")
        {
            DeclareIllust();
            if(resEvent[index].name == "선택지1") activeSelect();
            else {
            UpdateBeforeDialogue(index);
            StartCoroutine(TypeLine());
            }
        }    
        else
        {
            if(resEvent[index].name == "end") {
                switch (resEvent[index].script) {
                    case "up": 
                        if (Managers.Player.playerInfoData.npc_bond[resNpcId]<5) Managers.Player.playerInfoData.npc_bond[resNpcId]+=1;
                        Debug.Log(Managers.Player.playerInfoData.npc_bond[resNpcId]);
                        break;
                    case "down":
                        if(Managers.Player.playerInfoData.npc_bond[resNpcId]>0) Managers.Player.playerInfoData.npc_bond[resNpcId]-=1;
                        break;
                    default: return;
                }
            }
            DialogueBox.SetActive(false);
            StaindingImg.SetActive(false);
            SceneManager.LoadScene("MonthlyResultScene");
        }  
    }

    void UpdateBeforeDialogue(int index) {
        var spriteId = staindingId[resEvent[index].name];

        textComponent.text = string.Empty;
        if (standingList[spriteId].id == 2)
        {
         textComponent2.text = string.Empty;
         NameSlot.SetActive(false);
         }
        else {
            textComponent2.text = resEvent[index].name;
            NameSlot.SetActive(true);
            }

        Debug.Log(standingList[spriteId].image);
        standingImg.sprite = Resources.Load<Sprite>(standingList[spriteId].image);
        standingImg.transform.localPosition = new Vector3(standingList[spriteId].locationX,standingImg.transform.localPosition.y,standingImg.transform.localPosition.z);
    }

    void activeSelect() {
        preventClick = true;
        StopAllCoroutines();
        selectUi.SetActive(true);
        select1.text = resEvent[index].script;
        select2.text = resEvent[index2].script;
    }

    public void onClickSelect1() {
        selectUi.SetActive(false);
        index++;
        preventClick = false;
        StartCoroutine(TypeLine());
    }

    public void onClickSelct2() {
        selectUi.SetActive(false);
        index = index2+1;
        preventClick = false;
        NextLine();
    }

    public void bondUpSkip() {
        if (Managers.Player.playerInfoData.npc_bond[resNpcId]<5) Managers.Player.playerInfoData.npc_bond[resNpcId]+=1;
        SceneManager.LoadScene("MonthlyResultScene");
    }
    public void bondDownSkip() {
        if(Managers.Player.playerInfoData.npc_bond[resNpcId]>0) Managers.Player.playerInfoData.npc_bond[resNpcId]-=1;              
        SceneManager.LoadScene("MonthlyResultScene");
    }

}

