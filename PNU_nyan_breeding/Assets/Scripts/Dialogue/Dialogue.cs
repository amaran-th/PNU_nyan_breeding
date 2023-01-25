using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public static Dictionary<int,EndingDialogue> dialogueList;
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    void Awake() {
        dialogueList = Managers.Data.dialogueList;
    }
    void Start()
    {
        textComponent.text = string.Empty;
        Debug.Log(dialogueList[0].script);
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialogueList[index].script)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueList[index].script;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueList[index].script.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < dialogueList.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }    
        else
        {
            gameObject.SetActive(false);
        }  
    }
}
