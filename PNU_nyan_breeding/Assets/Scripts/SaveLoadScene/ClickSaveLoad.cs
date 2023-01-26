using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


// 일단은 슬롯을 총 3개로 가정

public class ClickSaveLoad : MonoBehaviour
{
    public GameObject SaveCheck;
    public GameObject SaveSlotPage;
    public string path;
    public Player nowPlayer = new Player();
    public int slotNumber;

    private void Awake()
    {
        path = Application.persistentDataPath + "/" + "save";
    }

    void Start()
    {

    }

    /*public void LoadSlot(int number)
    {
        DataManage.instance.slotNumber = number;

        //if(isSaveFileExists[number])
        //{
            DataManage.instance.LoadData();
        //}
    }*/

    /*public void LoadSlot(int number)
    {
        slotNumber = number;
        string data = File.ReadAllText(path + slotNumber.ToString());
        nowPlayerData = JsonUtility.FromJson<PlayerData>(data);
    }*/


    public void SaveSlot(int number)
    {
        slotNumber = number;
        SaveSlotPage.SetActive(false);
        SaveCheck.SetActive(true);
    }

    public void SaveYesBtnClicked() {
        //SaveBtn.GetComponent<ChangePage>().SaveBtnClicked();
        //GameObject.Find("ChangePage").GetComponent<ChangePage>().SaveBtnClicked();
        SaveData();
        SaveSlotPage.SetActive(true);
        SaveCheck.SetActive(false);
    }

    public void SaveNoBtnClicked() {
        SaveCheck.SetActive(false);
        SaveSlotPage.SetActive(true);
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + slotNumber.ToString(), data);
    }

    
}