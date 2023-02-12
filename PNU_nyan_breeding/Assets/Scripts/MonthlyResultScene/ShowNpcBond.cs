using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowNpcBond : MonoBehaviour
{
    public RectTransform contents;
    public GameObject listItemGO;
    public TMP_Text text;

    void Start(){
        LoadNPCInfo();
        if(ShareData.selectedNPCId!=-1){
            text.text=MonthlyResultManager.npcData[ShareData.selectedNPCId].name+"와 조금 친해졌다!";
        }else{
            text.text="이번 달엔 아무와도 만나지 않았다!";
        }
        
    }
    void LoadNPCInfo(){
        for(int i=0;i<MonthlyResultManager.npcData.Count;i++){
            var listItem=Instantiate(listItemGO, contents); //자식 객체 생성
            listItem.transform.SetParent(GameObject.Find("Content").transform); //위치 설정
            var testListItem=listItem.GetComponent<NpcBond>();
            var bond=MonthlyResultManager.playerInfoData.npc_bond[i];
            var storyCount=MonthlyResultManager.playerInfoData.npc_story_count[i];
            testListItem.Init(MonthlyResultManager.npcData[i], storyCount, bond);        
        }
    }
}
