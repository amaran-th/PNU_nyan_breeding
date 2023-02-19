using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NpcBond : MonoBehaviour
{
    public Image icon;
    public TMP_Text name;
    public RectTransform contents;
    public Image fill;
    public Image noFill;
    
    
    public void Init(NPC npc, int storyCount, int bond){
        this.icon.sprite=Resources.Load<Sprite>(npc.img_path) as Sprite;
        this.name.text=npc.name;
        Debug.Log(npc.name+"과"+storyCount.ToString()+"번 만났고, 호감도는"+bond);
        LoadBond(bond);
        //npcList=transform.parent.parent.parent.GetComponent<ScrollRect>();
    }
    
    void LoadBond(int num){
        for(int i=0;i<5;i++){
            var heart=fill;
            if(i>=num) heart=noFill;
            var listItem=Instantiate(heart, contents); //자식 객체 생성
            listItem.transform.SetParent(contents.transform); //위치 설정        
        }
    }
}
