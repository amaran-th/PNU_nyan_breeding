using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeciesIcon : MonoBehaviour
{
    public int index;

    void Update()
    {
        if(SelectSpecies.currentSpecies == index){
            GetComponent<Image>().color= new Color32(255, 255, 255, 255);;
        }else{
            GetComponent<Image>().color= new Color32(100, 100, 100, 100);;
        }
    }
    public void OnClickIcon(){
        SelectSpecies.currentSpecies = index;
    }
}