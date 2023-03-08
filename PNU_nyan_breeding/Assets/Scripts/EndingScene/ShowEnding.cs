using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShowEnding : MonoBehaviour
{
    
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textComponent2;
    public GameObject DialogueBox;
    public GameObject ReturnButton;
    public GameObject NameSlot;
    public float textSpeed;
    private int index = 0;
    public Dictionary<int,EndingDialogue> ending;
    public static Dictionary<int, Standing> standingList = new Dictionary<int, Standing>();
    public Dictionary<string, string> staindingId = new Dictionary<string, string>()
    {      
      {"0",   "부대냥" },
      {"1",   "캔따개" },
      {"2",   "학생회장"},
      {"3",   "교수님"},
      {"11",  "캔따개"},
    };

    public Image standingImg;
    public Image endingIllust;
    public Image backgroundImg;
    //string playerName = EndingManager.playerInfoData.name;
    string playerName = "임시이름"; //temp 
    
    
    private bool preventClick = false;

    void Awake() {
        DialogueBox.SetActive(true);
        ReturnButton.SetActive(false);
        endingIllust.color = new Color(1,1,1,0);
        standingList = Managers.Data.standingList;
    }
    void Start()
    {
        ending = ShareData.resEnding;  
        Debug.Log("showEnding");
        //Debug.Log(ending[index].background);
        backgroundImg.sprite = Resources.Load<Sprite>(ending[index].background);
        textComponent.text = string.Empty;
        textComponent2.text = string.Empty;
        
        Debug.Log("ending count: "+ending.Count+" index: "+index);
        NextLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !preventClick)
        {
            Debug.Log(textComponent.text);
            Debug.Log(ending[index].script.Replace("[부대냥]", playerName));
            Debug.Log("ending count: "+ending.Count+" index: "+index);
            if (textComponent.text == ending[index].script.Replace("[부대냥]", playerName))
            {
                
                index++;
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = ending[index].script.Replace("[부대냥]", playerName);
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in ending[index].script.Replace("[부대냥]", playerName).ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        
        Debug.Log("ending count: "+ending.Count+" index: "+index+"index < ending.Count-1 ?: "+(index < ending.Count));
        if(index < ending.Count  )
        {
            UpdateBeforeDialogue(index);
            StartCoroutine(TypeLine());
        }    
        else
        {
            DialogueBox.SetActive(false);
            preventClick = true;
            ReturnButton.SetActive(true);
        }  
    }

    void UpdateBeforeDialogue(int index) {
        var spriteId = 0;
        textComponent.text = string.Empty;
        //스탠딩이 존재하는지 확인
        if (staindingId.ContainsKey(ending[index].name)) {
            NameSlot.SetActive(true);
            spriteId = int.Parse(ending[index].name);
            textComponent2.text =  staindingId[ending[index].name];
            standingImg.sprite = Resources.Load<Sprite>(standingList[spriteId].image);
            standingImg.transform.localPosition = new Vector3(standingList[spriteId].locationX,standingImg.transform.localPosition.y,standingImg.transform.localPosition.z);
        
        }
        else if (ending[index].name == "나레이션") {
            textComponent2.text = string.Empty;
            NameSlot.SetActive(false);
            standingImg.sprite = Resources.Load<Sprite>(standingList[12].image);
        }
        else if (ending[index].name == "일러스트") {
            standingImg.sprite = Resources.Load<Sprite>(standingList[12].image);
            DialogueBox.SetActive(false);
            textComponent.text = string.Empty;
            preventClick = true;
            endingIllust.sprite = Resources.Load<Sprite>(ending[index].background);
            StartCoroutine(IllustAppears());
            return;
        }
        else {
            NameSlot.SetActive(true);
            textComponent2.text = ending[index].name;
            standingImg.sprite = Resources.Load<Sprite>(standingList[12].image);
        }

        //Debug.Log(standingList[spriteId].image);
        backgroundImg.sprite = Resources.Load<Sprite>(ending[index].background);

    }

    public void ReturnToMain() {
        SceneManager.LoadScene("TitleScene");
    }

    IEnumerator IllustAppears() {
        Debug.Log("appears");
        float fadeCount = 0;
        while (fadeCount < 1.0f) {
            fadeCount += 0.01f;
            // Debug.Log(fadeCount);
            yield return new WaitForSeconds(0.01f);
            endingIllust.color = new Color(1,1,1,fadeCount);
        }
        yield return new WaitForSeconds(1.0f);
        DialogueBox.SetActive(true);
        preventClick = false;
    }
}
