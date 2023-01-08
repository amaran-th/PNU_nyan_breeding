using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSpecies : MonoBehaviour
{
    public GameObject species;
    // Start is called before the first frame update
    void Start()
    {
        CreateSelectSpecies();
    }

    public void CreateSelectSpecies(){   //NPC 아이콘 생성
        for(int i=0;i<SelectManager.catSpeciesData.Count;i++){
            var catSpecies=(CatSpecies)SelectManager.catSpeciesData[i];
            var speciesItem=Instantiate(species,transform); //자식 객체 생성
            speciesItem.transform.localPosition=new Vector3(90f*catSpecies.id, 0f, 0f);      
            speciesItem.GetComponent<Image>().sprite=Resources.Load<Sprite>(catSpecies.img_path) as Sprite;      
            //(npcItem.transform.Find("NpcObject").GetComponent("NPCIcon") as NPCIcon).index=npc.id;
        }
    }
}
