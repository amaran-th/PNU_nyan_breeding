using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJManager : MonoBehaviour
{
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;
    
     void Awake(){
        playerInfoData = Managers.Player.playerInfoData;
        playerStatData = Managers.Player.playerStatData;
        //Debug.Log(playerInfoData.name);
        CreateSelectSpecies();
    }

    public void CreateSelectSpecies(){   //NPC 아이콘 생성
        Debug.Log(playerInfoData.name);

        // for(int i=0;i<playerStatData.Count;i++){
        //     var catSpecies=(CatSpecies)SelectManager.catSpeciesData[i];
        //     var speciesItem=Instantiate(species,transform); //자식 객체 생성
        //     speciesItem.name = "SpeciesObj";//자식객체 이름 설정
        //     speciesItem.transform.localPosition=new Vector3(80f*catSpecies.id, 0f, 0f);      
        //     speciesItem.GetComponent<Image>().sprite=Resources.Load<Sprite>(catSpecies.img_path) as Sprite;      
        //     speciesItem.GetComponent<SpeciesIcon>().index = i;
        // }
    }

}
