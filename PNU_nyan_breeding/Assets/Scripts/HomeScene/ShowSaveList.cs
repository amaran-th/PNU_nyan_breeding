using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ShowSaveList : MonoBehaviour
{
    public GameObject SaveCheck;
    public GameObject SaveSlotPage;
    public GameObject CloseBtn;
    private string path;
    public int slotNumber;

    bool[] isSaveFileExists = new bool[3];
    public TMP_Text[] slotText;

    public void CloseBtnClicked()
    {
        SaveSlotPage.SetActive(false);
    }

    public void SaveSlot(int number)
    {
        slotNumber = number;
        SaveSlotPage.SetActive(false);
        SaveCheck.SetActive(true);
    }

    public void ShowSaveSlot()
    {
        for (int i=0; i<3; i++)
        {
            if(File.Exists(path + $"{i}"))
            {
                isSaveFileExists[i] = true;
                slotNumber = i;
                slotText[i].text = "Already Saved";
            }
            else
            {
                slotText[i].text = "Empty";
            }
        }
        //DataManage.instance.DataClear();
    }

    private void Awake()
    {
        path = Application.persistentDataPath + "/" + "save";
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowSaveSlot();
    }

    // Update is called once per frame
    void Update()
    {
        ShowSaveSlot();
    }
}