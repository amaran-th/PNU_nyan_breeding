using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButtonController : MonoBehaviour
{
    public void OnClickNpcOK(){
        ShareData.selectedNPCId=MapManager.currentNpc;
        SceneManager.LoadScene("NpcEventScene");
    }
    public void OnClickLottoButton(){
        ModalManager.instance.YesOrNoOpenModal("(무료)인생 한 방! 한 달에 한 번 찾아오는 냥냥로또! 당신의 운을 시험해보시겠습니까?",OnClickLottoOK,OnClickCancel);
    }
    public void OnClickLottoOK(){
        ShareData.isLotto=true;
        SceneManager.LoadScene("MonthlyResultScene");
    }
    public void OnClickCancel(){}
    public void OnClickSkipButton(){
        ModalManager.instance.YesOrNoOpenModal("정말로 아무도 만나지 않고 다음으로 넘어가시겠습니까?",OnClickSkipOK,OnClickCancel);
    }
    public void OnClickSkipOK(){
        SceneManager.LoadScene("MonthlyResultScene");
    }
    
}
