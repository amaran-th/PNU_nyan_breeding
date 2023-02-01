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
    public float textSpeed;
    private int index = 0;
    public Dictionary<int,EndingDialogue> ending =  new Dictionary<int,EndingDialogue>();
    public static Dictionary<int, Standing> standingList = new Dictionary<int, Standing>();
    public Dictionary<string, int> staindingId = new Dictionary<string, int>()
    {
      {"교수님", 0 },
      {"깜냥이", 1 },
      {"나레이션", 2}
    };

    public Image tempImg;

    // Start is called before the first frame update
    void Awake() {
        DialogueBox.SetActive(true);
        ReturnButton.SetActive(false);
        standingList = Managers.Data.standingList;
        
    }
    void Start()
    {
        Debug.Log("showEnding");
        ending = GameObject.Find("Canvas").GetComponent<CalculateEnding>().resEnding;
        textComponent.text = string.Empty;
        textComponent2.text = string.Empty;
        
        Debug.Log(standingList[index]);
        Debug.Log(ending[index]);
        Debug.Log(ending[index].script);
        NextLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
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
        if(index < ending.Count - 1)
        {
            UpdateBeforeDialogue(index);
            StartCoroutine(TypeLine());
        }    
        else
        {
            //DialogueBox.SetActive(false);
            ReturnButton.SetActive(true);
        }  
    }

    void UpdateBeforeDialogue(int index) {
        var spriteId = staindingId[ending[index].name];

        textComponent.text = string.Empty;
        if (standingList[spriteId].id == 2)
         textComponent2.text = string.Empty;
        else textComponent2.text = ending[index].name;

        Debug.Log(standingList[spriteId].image);
        tempImg.sprite = Resources.Load<Sprite>(standingList[spriteId].image);
        tempImg.transform.localPosition = new Vector3(standingList[spriteId].locationX,tempImg.transform.localPosition.y,tempImg.transform.localPosition.z);
    }

    public void ReturnToMain() {
        SceneManager.LoadScene("TitleScene");
    }
}
