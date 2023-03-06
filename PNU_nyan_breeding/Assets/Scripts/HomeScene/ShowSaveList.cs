using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ShowSaveList : MonoBehaviour
{
    private Player playerData = new Player();
    public GameObject SaveCheck;
    public GameObject SaveSlotPage;
    public GameObject Shadow;
    public GameObject CloseBtn;
    private string path;
    public static int slotNumber;

    public Image[] catImage;
    public TMP_Text[] FileNames;
    public TMP_Text[] UnivAndNames;
    public TMP_Text[] YearAndMonth;

    public void CloseBtnClicked()
    {
        SaveSlotPage.SetActive(false);
        Shadow.SetActive(false);
    }

    public void SaveSlot(int number)
    {
        slotNumber = number;
        SaveSlotPage.SetActive(false);
        SaveCheck.SetActive(true);
    }

    public void ShowSaveSlot()
    {
        Shadow.SetActive(true);
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

    public int GetSlotNumber()
    {
        return slotNumber;
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