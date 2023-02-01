using System.Collections;
 using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //public static Dictionary<int,EndingDialogue> dialogueList;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textComponent2;
    public float textSpeed;
    private int index;

    public static Dictionary<int, Standing> standingList;
    public Dictionary<string, int> staindingId = new Dictionary<string, int>()
    {
      {"교수님", 0 },
      {"깜냥이", 1 },
      {"나레이션", 2}
    };
    public Image tempImg;

    // Start is called before the first frame update
    void Awake() {
        //dialogueList = Managers.Data.dialogueList;
        standingList = Managers.Data.standingList;
        //tempImg = GetComponent<Image>(); //이상하게 이거하면 imgae만 움직이는게 아니라 다이얼로그 컴포넌트 전부 다 움직임
        
    }
    // void Start()
    // {
    //     textComponent.text = string.Empty;
    //     textComponent2.text = string.Empty;
    //     StartDialogue();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         if (textComponent.text == dialogueList[index].script)
    //         {
    //             NextLine();
    //         }
    //         else
    //         {
    //             StopAllCoroutines();
    //             textComponent.text = dialogueList[index].script;
    //         }
    //     }
    // }

    // void StartDialogue()
    // {
    //     index = 0;
    //     textComponent2.text = dialogueList[index].name;
    //     var spriteId = staindingId[dialogueList[index].name];
    //     tempImg.sprite = Resources.Load<Sprite>(standingList[spriteId].image) as Sprite;
    //     tempImg.transform.localPosition = new Vector3(standingList[spriteId].locationX,tempImg.transform.localPosition.y,tempImg.transform.localPosition.z);
    //     StartCoroutine(TypeLine());
    // }

    // IEnumerator TypeLine()
    // {
    //     foreach (char c in dialogueList[index].script.ToCharArray())
    //     {
    //         textComponent.text += c;
    //         yield return new WaitForSeconds(textSpeed);
    //     }
    // }

    // void NextLine()
    // {
    //     if(index < dialogueList.Count - 2)
    //     {
    //         index++;
    //         textComponent.text = string.Empty;
    //         textComponent2.text = dialogueList[index].name;
    //         var spriteId = staindingId[dialogueList[index].name];
    //         Debug.Log(standingList[spriteId].image);
    //         tempImg.sprite = Resources.Load<Sprite>(standingList[spriteId].image);
    //         tempImg.transform.localPosition = new Vector3(standingList[spriteId].locationX,tempImg.transform.localPosition.y,tempImg.transform.localPosition.z);
    //         StartCoroutine(TypeLine());
    //     }    
    //     else
    //     {
    //         gameObject.SetActive(false);
    //     }  
    // }
}
