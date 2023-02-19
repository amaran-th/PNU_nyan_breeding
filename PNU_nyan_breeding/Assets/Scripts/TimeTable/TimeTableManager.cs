using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeTableManager : MonoBehaviour
{
    public static List<Dictionary<int, Activity>> activityDataList;   //DataManager를 통해 로드된 활동 데이터
    public static int grade;
    public static int month;
    public static int curMoney;
    public static int selectedMoney;
    public static GameObject tooltip;
    public GameObject dateUI;
    public GameObject moneyUI;

    void Awake(){
        grade=Managers.Player.playerInfoData.grade;
        month=Managers.Player.playerInfoData.month;
        curMoney=Managers.Player.playerInfoData.money_stat;
        selectedMoney=0;
        //Json 파일로부터 데이터 로드
        activityDataList = Managers.Data.activityDataList; 
        tooltip = GameObject.Find("Tooltip").transform.Find("Texts").gameObject;
        tooltip.SetActive(false);
        dateUI.transform.Find("Grade").gameObject.GetComponent<TMP_Text>().text=grade+"학년";
        dateUI.transform.Find("Month").gameObject.GetComponent<TMP_Text>().text=month+"월";
        moneyUI.transform.Find("Money").gameObject.GetComponent<TMP_Text>().text=curMoney+"냥";
    }
    public void OnClickNextButton() {
        ShareData.fixedScheduleList=CalenderController.scheduleList;
        SceneManager.LoadScene("MapScene");
    }

    public void OnClickPrevButton(){
        ModalManager.instance.YesOrNoOpenModal("홈 화면으로 돌아가겠습니까?",PrevScene,Pass);
    }
    public void PrevScene(){
        SceneManager.LoadScene("HomeScene");
    }
    public void Pass(){}
    
}
