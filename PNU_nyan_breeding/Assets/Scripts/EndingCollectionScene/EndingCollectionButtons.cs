using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndingCollectionButtons : MonoBehaviour
{
    public Image[] EndingImage;
    public TMP_Text[] EndingName;
    public TMP_Text[] EndingDate;
    public Button LeftBtn;
    public Button RightBtn;
    private int page=0;
    Dictionary<int, Page> endingDict;

    void Start()
    {
        LeftBtn.interactable=false;
        RightBtn.interactable=true;
        Debug.Log(JsonUtility.ToJson(EndingCollectionManager.endingCollectionData));
        endingDict = EndingCollectionManager.endingCollectionData.MakeDict();

        for(int i=0; i<4; i++) {
            // done에 따라 이미지, 글자 활성화
            EndingName[i].text = endingDict[0].ending[i].endingName;
            EndingDate[i].text = endingDict[0].ending[i].done.ToString();
        }
    }

    public void GoTitleButtonOnClick() 
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void FlipPageLeft()
    {
        page--;
        if(page==0) {
            LeftBtn.interactable=false;
            RightBtn.interactable=true;
        }
        else {
            LeftBtn.interactable=true;
            RightBtn.interactable=true;
        }
        //Debug.Log(JsonUtility.ToJson(endingDict[1]));

        for(int i=0; i<4; i++) {
            EndingName[i].text = endingDict[page].ending[i].endingName;
            EndingDate[i].text = endingDict[page].ending[i].done.ToString();
        }
    }

    public void FlipPageRight()
    {
        page++;
        if(page==1) {
            LeftBtn.interactable=true;
            RightBtn.interactable=false;
        }
        else {
            RightBtn.interactable=true;
            LeftBtn.interactable=true;
        }

        for(int i=0; i<4; i++) {
            EndingName[i].text = endingDict[page].ending[i].endingName;
            EndingDate[i].text = endingDict[page].ending[i].done.ToString();
        }
    }

    public void ShowData()
    {
        // Debug.Log(EndingCollectionManager.endingData);
    }

    void Update()
    {
    }
}
