using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject npcIcon;
    public RectTransform canvas;
    public GameObject choiceModal;
    public GameObject selector;
    public static Dictionary<int, NPC> npcData;   //DataManager를 통해 로드된 활동 데이터

    //npc
    public static int currentNpc = -1;
    int newNpc = -1;
    
    //현재 선택된 npc가 변할 때마다
    public int detectNpc{
        set{
            if (newNpc == value) return;
            newNpc = value;
            UpdateModal();
            UpdateSelector();
        }
        get{
            return newNpc;
        }
    }


    void Awake(){
        //Json 파일로부터 데이터 로드
        npcData = Managers.Data.npcData;  
        currentNpc=-1;  
        CreateNPCIcons();
    }
    void Start()
    {
        UpdateModal();
        UpdateSelector();
    }

    void Update()
    {
        detectNpc=currentNpc;
    }
    public void CreateNPCIcons(){   //NPC 아이콘 생성
        for(int i=0;i<npcData.Count;i++){
            var npc=(NPC)npcData[i];
            var npcItem=Instantiate(npcIcon,canvas); //자식 객체 생성
            npcItem.transform.localPosition=new Vector3(npc.pos_x, npc.pos_y, 0f);            
            (npcItem.GetComponent("NPCIcon") as NPCIcon).index=npc.id;
            //npcItem.GetComponent<Image>().sprite=Resources.Load<Sprite>(npc.img_path) as Sprite;
            //npcItem.transform.SetParent(GameObject.Find("").transform); //위치 설정
            //var testListItem=npcItem.GetComponent<NPCIcon>();
            //testListItem.Init(npc);
            Debug.Log(npc.name);
            //transform.SetParent(GameObject.Find("Content").transform);
        }
    }
    void UpdateModal(){
        if(currentNpc>=0){
            choiceModal.SetActive(true);
        }else{
            choiceModal.SetActive(false);
        }
    }
    void UpdateSelector(){
        if(currentNpc>=0){
            var currentData=npcData[currentNpc];
            selector.SetActive(true);
            selector.transform.localPosition=new Vector3(currentData.pos_x,currentData.pos_y,0f);
        }else{
            selector.SetActive(false);
        }
    }
}
