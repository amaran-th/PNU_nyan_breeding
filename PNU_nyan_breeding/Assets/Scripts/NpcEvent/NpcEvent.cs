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

    private int index = 0;
    private int index2=0;
    private bool preventClick = false;
    public Dictionary<int, TempEvent> resEvent =new Dictionary<int, TempEvent>();
    public static Dictionary<int, Standing> standingList = new Dictionary<int, Standing>();
    public Dictionary<string, int> staindingId = new Dictionary<string, int>()
    {
      {"교수님", 0 },
      {"깜냥이", 1 },
      {"나레이션", 2}
    };

    public Image tempImg;

    void Awake() {
        Debug.Log("NpcEvent");
        selectUi.SetActive(false);
        DialogueBox.SetActive(true);
        standingList = Managers.Data.standingList;
    }

    void setIndex2() {
        while(resEvent[index2].name != "선택지2") index2++;
        Debug.Log("index2: "+index2);
    }

    void Start()
    {
        
        index2 = index+1;
        textComponent.text = string.Empty;
        textComponent2.text = string.Empty;
        resEvent = GameObject.Find("Canvas").GetComponent<EventList>().resEvent;

        setIndex2();
        Debug.Log(resEvent[index]);
        Debug.Log(resEvent[index].script);
        
        Debug.Log("event count: "+resEvent.Count+" index: "+index);
        NextLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && !preventClick)
        {
            Debug.Log(textComponent.text);
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
        
        //Debug.Log("event count: "+resEvent.Count+" index: "+index+"index < event.Count-1 ?: "+(index < resEvent.Count));
        if(index < resEvent.Count && resEvent[index].name != "end")
        {
            if(resEvent[index].name == "선택지1") activeSelect();
            else {
            UpdateBeforeDialogue(index);
            StartCoroutine(TypeLine());
            }
        }    
        else
        {
            DialogueBox.SetActive(false);
            StaindingImg.SetActive(false);
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
        tempImg.sprite = Resources.Load<Sprite>(standingList[spriteId].image);
        tempImg.transform.localPosition = new Vector3(standingList[spriteId].locationX,tempImg.transform.localPosition.y,tempImg.transform.localPosition.z);
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

}

