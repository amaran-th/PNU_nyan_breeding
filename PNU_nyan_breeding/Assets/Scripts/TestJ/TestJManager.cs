using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJManager : MonoBehaviour
{
    public static PlayerInfo playerInfoData; 
    
     void Awake(){
        playerInfoData = Managers.Player.playerInfoData; 
        Debug.Log(playerInfoData.name);
        CreateSelectSpecies();
    }

    public void CreateSelectSpecies(){   //NPC 아이콘 생성
        // for(int i=0;i<playerInfoData.Count;i++){
        //     var catSpecies=(CatSpecies)SelectManager.catSpeciesData[i];
        //     var speciesItem=Instantiate(species,transform); //자식 객체 생성
        //     speciesItem.name = "SpeciesObj";//자식객체 이름 설정
        //     speciesItem.transform.localPosition=new Vector3(80f*catSpecies.id, 0f, 0f);      
        //     speciesItem.GetComponent<Image>().sprite=Resources.Load<Sprite>(catSpecies.img_path) as Sprite;      
        //     speciesItem.GetComponent<SpeciesIcon>().index = catSpecies.id;
        // }
    }

}
