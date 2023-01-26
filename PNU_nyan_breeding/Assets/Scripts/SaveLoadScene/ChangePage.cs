using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ChangePage : MonoBehaviour
{
    public GameObject Page;
    public GameObject SaveSlotPage;
    public GameObject SaveBtn;
    public GameObject CloseBtn;

    public string path;
    public int slotNumber;


    bool[] isSaveFileExists = new bool[3];
    public TMP_Text[] slotText;

    private void Awake()
    {
        path = Application.persistentDataPath + "/" + "save";
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void CloseBtnClicked()
    {
        SaveSlotPage.SetActive(false);
    }

    public void SaveBtnClicked()
    {
        SaveSlotPage.SetActive(true);
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

    // Update is called once per frame
    void Update()
    {

    }
}