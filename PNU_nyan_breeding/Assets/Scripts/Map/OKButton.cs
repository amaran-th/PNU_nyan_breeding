using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OKButton : MonoBehaviour
{
    public void OnClickNpcOK(){
        ShareData.selectedNPCId=MapManager.currentNpc;
        SceneManager.LoadScene("NpcEventScene");
    }
    public void OnClickSkipOK(){
        SceneManager.LoadScene("MonthlyResultScene");
    }
    public void OnClickLottoOK(){
        //ShareData.lotto=Random.Range(0,100);
        ShareData.isLotto=true;
        SceneManager.LoadScene("MonthlyResultScene");

    }

}
