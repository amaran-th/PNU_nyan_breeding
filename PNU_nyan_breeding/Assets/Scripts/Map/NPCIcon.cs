using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCIcon : MonoBehaviour
{
    public int index;
    
    private NPC data;
    // Start is called before the first frame update
    void Start()
    {
        data=MapManager.npcData[index];
        GetComponent<Image>().sprite=Resources.Load<Sprite>(data.img_path) as Sprite;
        Debug.Log(data.img_path);
    }

    // Update is called once per frame
    void Update()
    {
        if(MapManager.currentNpc==index){
            transform.Find("Selector").gameObject.SetActive(true);
        }else{
            transform.Find("Selector").gameObject.SetActive(false);
        }
    }
    public void OnClickIcon(){
        MapManager.currentNpc=index;
        ModalManager.instance.YesOrNoOpenModal(MapManager.npcData[index].name+"을(를) 만나러 갈까?",OnClickNpcOK,OnClickCancel);
        Debug.Log(MapManager.currentNpc);
    }
    public void OnClickNpcOK(){
        ShareData.selectedNPCId=MapManager.currentNpc;
        //MapManager.playerInfoData.UpdateStoryCount(MapManager.currentNpc);
        SceneManager.LoadScene("NpcEventScene");
    }
    public void OnClickCancel(){}
}
