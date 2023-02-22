using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

using UnityEngine.SceneManagement;

public class ShowLoadList : MonoBehaviour
{
    private Player playerData = new Player();
    public GameObject LoadSlotPage;
    public GameObject Shadow;
    public GameObject CloseBtn;
    private string path;
    public static int slotNumber;

    // bool[] isSaveFileExists = new bool[3];
    public Image[] catImage;
    public TMP_Text[] FileNames;
    public TMP_Text[] UnivAndNames;
    public TMP_Text[] YearAndMonth;

    public void CloseBtnClicked()
    {
        LoadSlotPage.SetActive(false);
        Shadow.SetActive(false);
    }

    public void LoadSlot(int number)
    {
        slotNumber = number;
        Shadow.SetActive(false);
        LoadSlotPage.SetActive(false);
    }

    public void ShowLoadSlot()
    {
        for (int i=0; i<3; i++)
        {
            if(File.Exists(path + $"{i}"))
            {
                // isSaveFileExists[i] = true;
                playerData = Managers.Player.LoadJson<Player>(path + $"{i}");
                slotNumber = i;
                // 파일 이름
                FileNames[i].text = $"파일{i+1}";
                // 고양이 이미지
                var catData = Managers.Data.catSpeciesDataList[playerData.playerInfo.species];
                catImage[i].sprite = Resources.Load<Sprite>(catData.img_path) as Sprite;
                // 대학, 이름
                UnivAndNames[i].text = $"{playerData.playerInfo.university}대학교 {playerData.playerInfo.name}";
                // 학년, 월
                YearAndMonth[i].text = $"{playerData.playerInfo.grade}학년 {playerData.playerInfo.month}월";
            }
            else
            {
                FileNames[i].text = "Empty";
            }
        }
        //DataManage.instance.DataClear();
    }

    public void LoadGameFromSave(int index)
    {
        playerData = Managers.Player.LoadJson<Player>(Application.persistentDataPath + $"/save{index}");
        Managers.Player.playerInfoData = playerData.playerInfo;
        PlayerPrefs.SetInt("continue", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LoadingScene");
    }

    private void Awake()
    {
        path = Application.persistentDataPath + "/" + "save";
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowLoadSlot();
    }

    // Update is called once per frame
    void Update()
    {
        ShowLoadSlot();
    }
}