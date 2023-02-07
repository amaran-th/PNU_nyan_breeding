using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MailController : MonoBehaviour
{
    public GameObject mailModal;
    TMP_Text title;
    TMP_Text sender;
    TMP_Text sendTime;
    TMP_Text content;
    GameObject normalButton;
    GameObject npcButton;
    GameObject lottoButton;
    GameObject winButton;
    bool mailFlag=false;    //메일 이벤트가 여러개 중복될 경우 순차적으로 실행되게 하기 위한 플래그

    //TODO ShareData로 변경
    int npcMail=1;
    void Awake(){
        title=mailModal.transform.Find("TextTitle").GetComponent<TextMeshProUGUI>();
        sender=mailModal.transform.Find("TextSender").GetComponent<TextMeshProUGUI>();
        sendTime=mailModal.transform.Find("TextSendtime").GetComponent<TextMeshProUGUI>();
        content=mailModal.transform.Find("TextContent").GetComponent<TextMeshProUGUI>();
        normalButton=mailModal.transform.Find("NormalButton").gameObject; //일반적인 닫기 버튼
        npcButton=mailModal.transform.Find("NpcButton").gameObject; //승낙/거절 버튼. 이걸 쓸 지 모르겠네
        lottoButton=mailModal.transform.Find("LottoButton").gameObject; //로또 결과 확인 버튼
        winButton=mailModal.transform.Find("WinButton").gameObject; //로또 당첨금 수령 버튼. 클릭하면 바로 부자엔딩으로 직행
    }
    void Update(){
        if(mailFlag==false&&ShareData.isLotto){
            ActiveLottoMail();
        }
        if(mailFlag==false&&npcMail>=0){
            ActiveNpcMail();
        }
    }
   
    void ActiveLottoMail(){
        mailFlag=true;
        mailModal.SetActive(true);
        lottoButton.SetActive(true);

        title.text="[웹 발신]로또 안내...";
        sender.text="한국로또협회";
        sendTime.text="방금 전";
        content.text="안녕하세요"+Managers.Player.playerInfoData.name+"님, 로또 이벤트에 참여해주셔서 감사합니다.\n하단의 버튼을 누르시면 결과를 확인할 수 있습니다. ";
    }
    
    public void OnClickLottoButton(){
        ShareData.isLotto=false;
        var lottoNum=Random.Range(0,100);
        if(lottoNum<10){    //10% 확률
            content.text=lottoNum+"축하드립니다!";
            CloseAllButton();
            winButton.SetActive(true);
            return;
        }
        content.text="너무 아쉬워요~ 다음 기회에!";
        CloseAllButton();
        normalButton.SetActive(true);
    }
    public void OnClickReceiveButton(){
        //TODO 부자 관련 플래그 세우기
        CloseAllButton();
        SceneManager.LoadScene("EnddingScene");
    }
    void ActiveNpcMail(){
        mailFlag=true;
        mailModal.SetActive(true);
        normalButton.SetActive(true);

        title.text="선택지 이벤트";
        sender.text=HomeManager.npcData[npcMail].name;
        sendTime.text="방금 전";
        content.text=HomeManager.npcData[npcMail].name+"로부터 도착한 메세지~";
        npcMail=-1;
    }
    public void OnClickCloseButton(){
        mailModal.SetActive(false);
        CloseAllButton();
        mailFlag=false;
    }
    public void CloseAllButton(){
        normalButton.SetActive(false);
        npcButton.SetActive(false);
        lottoButton.SetActive(false);
        winButton.SetActive(false);
    }
}
