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
    public Dictionary<int,EndingDialogue> ending =  new Dictionary<int,EndingDialogue>();
    public static Dictionary<int, Standing> standingList = new Dictionary<int, Standing>();
    public Dictionary<string, int> staindingId = new Dictionary<string, int>()
    {      
      {"부대냥", 0 },
      {"캔따개", 1 },
      {"학생회장", 2},
      {"교수님", 3 },
      {"캔따개2", 11 },
      {"나레이션", 12},
      {"일러스트", 13}
    };

    public Image standingImg;
    public Image endingIllust;
    public Image backgroundImg;
    
    private bool preventClick = false;

    
    public static List<Dictionary<int, EndingDialogue>> normalEnding; // 테스트용 임시

    // Start is called before the first frame update
    void Awake() {
        DialogueBox.SetActive(true);
        ReturnButton.SetActive(false);
        endingIllust.color = new Color(1,1,1,0);
        standingList = Managers.Data.standingList;
        normalEnding = Managers.Data.normalEnding; // 테스트용 임시
        
    }
    void Start()
    {
        Debug.Log("showEnding");
        //ending = GameObject.Find("Canvas").GetComponent<CalculateEnding>().resEnding;
        ending = normalEnding[0]; // 테스트용 임시
        Debug.Log(ending[index].background);
        backgroundImg.sprite = Resources.Load<Sprite>(ending[index].background);
        textComponent.text = string.Empty;
        textComponent2.text = string.Empty;
        
        Debug.Log(standingList[index]);
        Debug.Log(ending[index]);
        
        Debug.Log("ending count: "+ending.Count+" index: "+index);
        NextLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !preventClick)
        {
            Debug.Log(textComponent.text);
            Debug.Log(ending[index].script);
            Debug.Log("ending count: "+ending.Count+" index: "+index);
            if (textComponent.text == ending[index].script)
            {
                
                index++;
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = ending[index].script;
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in ending[index].script.ToCharArray())
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
        var spriteId = staindingId[ending[index].name];

        if (spriteId == 13) {
            DialogueBox.SetActive(false);    
            textComponent.text = string.Empty;
            preventClick = true;
            endingIllust.sprite = Resources.Load<Sprite>(ending[index].background);
            StartCoroutine(IllustAppears());
            return;
        }

        textComponent.text = string.Empty;
        if (standingList[spriteId].id == 12)
        {
         textComponent2.text = string.Empty;
         NameSlot.SetActive(false);
         }
        else {
            textComponent2.text = ending[index].name;
            NameSlot.SetActive(true);
            }

        Debug.Log(standingList[spriteId].image);
        standingImg.sprite = Resources.Load<Sprite>(standingList[spriteId].image);
        standingImg.transform.localPosition = new Vector3(standingList[spriteId].locationX,standingImg.transform.localPosition.y,standingImg.transform.localPosition.z);
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
            Debug.Log(fadeCount);
            yield return new WaitForSeconds(0.01f);
            endingIllust.color = new Color(1,1,1,fadeCount);
        }
        yield return new WaitForSeconds(1.0f);
        DialogueBox.SetActive(true);
        preventClick = false;
    }
}
