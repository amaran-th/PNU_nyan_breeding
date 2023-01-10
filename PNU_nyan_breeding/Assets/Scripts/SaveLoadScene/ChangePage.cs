using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ChangePage : MonoBehaviour
{
    public GameObject Page;
    public GameObject SelectSaveLoadPage;
    public GameObject SelectSlotPage;
    public GameObject LoadBtn;
    public GameObject SaveBtn;
    public GameObject CloseBtn;

    bool[] isSaveFileExists = new bool[3];
    public TMP_Text[] slotText;

    // Start is called before the first frame update
    void Start()
    {
    }
 
    public void SaveLoadBtnClicked()
    {
        Page.SetActive(false);
        SelectSaveLoadPage.SetActive(true);
    }

    public void CloseBtnClicked()
    {
        SelectSaveLoadPage.SetActive(false);
        Page.SetActive(true);
    }

    public void LoadBtnClicked()
    {
        SelectSaveLoadPage.SetActive(false);
        SelectSlotPage.SetActive(true);
    }

    public void SaveBtnClicked()
    {
        SelectSaveLoadPage.SetActive(false);
        SelectSlotPage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
