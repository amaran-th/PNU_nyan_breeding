using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject npcIcon;
    public RectTransform canvas;
    public GameObject choiceModal;
    public static Dictionary<int, NPC> npcData;   //DataManager를 통해 로드된 활동 데이터
    public static PlayerInfo playerInfoData;
    //npc
    public static int currentNpc = -1;
    int newNpc = -1;
    
    //현재 선택된 npc가 변할 때마다
    public int detectNpc{
        set{
            if (newNpc == value) return;
            newNpc = value;
        }
        get{
            return newNpc;
        }
    }


    void Awake(){
        //Json 파일로부터 데이터 로드
        npcData = Managers.Data.npcData;  
        playerInfoData= Managers.Player.playerInfoData;
        currentNpc=-1;  
        CreateNPCIcons();
    }

    void Update()
    {
        detectNpc=currentNpc;
    }
    public void CreateNPCIcons(){   //NPC 아이콘 생성
        for(int i=0;i<npcData.Count;i++){
            if (Managers.Player.playerInfoData.npc_story_count[i] == 9 && Managers.Player.playerInfoData.npc_bond[i] < 5) continue;
            else {
                var npc=(NPC)npcData[i];
                var npcItem=Instantiate(npcIcon,canvas); //자식 객체 생성
                npcItem.transform.localPosition=new Vector3(npc.pos_x, npc.pos_y, 0f);            
                (npcItem.transform.Find("NpcObject").GetComponent("NPCIcon") as NPCIcon).index=npc.id;
            }
        }
    }


}
