using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishButton1 : MonoBehaviour
{
    public GameObject practiceSelect;
    public Button finishButton;
    public GameObject shield;
    void Start(){
        shield.SetActive(false);
        UpdateFinishButton();
    }
    void Update()
    {
        UpdateFinishButton();
    }

    //활동을 추가/제거 할 때마다 선택된 활동 개수에 따라 완료 버튼을 활성화/비활성화한다.
    public void UpdateFinishButton(){
        if(CalenderController.scheduleCount==3){
            finishButton.interactable = true;
            ColorBlock colorBlock = finishButton.colors;
	        //(r, g, b, a) 기준 빨간색으로 normal Color 지정
            colorBlock.normalColor = new Color(1f, 0.5467f, 0.0226f, 1f);
            finishButton.colors = colorBlock;
        }else{
            finishButton.interactable = false;
            
        }
    }

    public void OnClickFinishButton(){
        //TODO 메모장 치우는 애니메이션 추가
        practiceSelect.SetActive(false);
        finishButton.gameObject.SetActive(false);
        shield.SetActive(true);
        Debug.Log("Finish!");
        ShareData.fixedScheduleList=CalenderController.scheduleList;
        SceneManager.LoadScene("MonthlyResultScene");
    }
}
