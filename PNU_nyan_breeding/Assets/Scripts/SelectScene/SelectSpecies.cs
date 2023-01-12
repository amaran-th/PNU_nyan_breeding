using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSpecies : MonoBehaviour
{
    public GameObject species;
    public static int currentSpecies = -1;
    int newSpecies = -1;
    
    //현재 선택된 npc가 변할 때마다
    public int detectSpecies{
        set{
            if (newSpecies == value) return;
            newSpecies = value;
        }
        get{
            return newSpecies;
        }
    }
    void Start(){
        CreateSelectSpecies();
    }
    void Update()
    {
        detectSpecies=currentSpecies;
    }

    public void CreateSelectSpecies(){   //NPC 아이콘 생성
        for(int i=0;i<SelectManager.catSpeciesData.Count;i++){
            var catSpecies=(CatSpecies)SelectManager.catSpeciesData[i];
            var speciesItem=Instantiate(species,transform); //자식 객체 생성
            speciesItem.name = "SpeciesObj";//자식객체 이름 설정
            speciesItem.transform.localPosition=new Vector3(80f*catSpecies.id, 0f, 0f);      
            speciesItem.GetComponent<Image>().sprite=Resources.Load<Sprite>(catSpecies.img_path) as Sprite;      
            speciesItem.GetComponent<SpeciesIcon>().index = catSpecies.id;
        }
    }
}