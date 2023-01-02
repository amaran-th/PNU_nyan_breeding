using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishButton : MonoBehaviour
{
    public GameObject practiceSelect;
    public Button finishButton;
    void Update()
    {
        
    }
    public void OnClickFinishButton(){
        //TODO 메모장 치우는 애니메이션 추가
        practiceSelect.SetActive(false);
        finishButton.gameObject.SetActive(false);
        Debug.Log("Finish!");
    }
}
