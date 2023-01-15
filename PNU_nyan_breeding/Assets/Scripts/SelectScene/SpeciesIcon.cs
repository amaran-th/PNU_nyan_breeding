using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeciesIcon : MonoBehaviour
{
    public int index;
    void Start()
    {
        var data=(CatSpecies)SelectManager.catSpeciesData[index];
        transform.Find("CatImage").GetComponent<Image>().sprite=Resources.Load<Sprite>(data.img_path) as Sprite;
        
    }    
    void Update()
    {
        if(SelectSpecies.currentSpecies == index){
            transform.Find("CatImage").gameObject.SetActive(true);
        }else{
            transform.Find("CatImage").gameObject.SetActive(false);
        }
    }

}