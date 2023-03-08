using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;


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
        //playerInfoPath = Application.dataPath + "/Resources/Json/player_info.json";
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
        //Managers.SaveData(saveFilePath + slotNumber.ToString(), HomeManager.PlayerData);
        HomeManager.playerData.playerInfo = HomeManager.playerInfoData;
        HomeManager.playerData.playerStat = HomeManager.playerStatData;
        string data = JsonUtility.ToJson(HomeManager.playerData);
        File.WriteAllText(saveFilePath + slotNumber.ToString(), data);
    }

    void Update()
    {
        slotNumber = ShowSaveList.slotNumber;
    }
    
}