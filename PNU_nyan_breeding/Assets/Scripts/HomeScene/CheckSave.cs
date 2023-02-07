using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


// 일단은 슬롯을 총 3개로 가정

public class CheckSave : MonoBehaviour
{
    public GameObject SaveCheck;
    public GameObject SaveSlotPage;
    private string saveFilePath;
    private string playerInfoPath;
    private int slotNumber;

    private void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/" + "save";
        playerInfoPath = Application.dataPath + "/Resources/Json/player_info.json";
    }

    public void SaveYesBtnClicked() 
    {
        MakeSaveFile();
        SaveSlotPage.SetActive(true);
        SaveCheck.SetActive(false);
    }

    public void SaveNoBtnClicked() {
        SaveCheck.SetActive(false);
        SaveSlotPage.SetActive(true);
    }

    public void MakeSaveFile()
    {
        System.IO.File.Copy(playerInfoPath, saveFilePath + slotNumber.ToString(), true);
        // vstring data = JsonUtility.ToJson(nowPlayer);
        // File.WriteAllText(path + slotNumber.ToString(), data);
    }

    
}