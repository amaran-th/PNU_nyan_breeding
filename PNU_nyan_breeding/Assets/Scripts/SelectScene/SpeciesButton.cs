using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesButton : MonoBehaviour
{
    public void ClickPreviousSpeciesBtn(){
        if (SelectSpecies.currentSpecies == 0 ){
            SelectSpecies.currentSpecies = 2;
        }
        else SelectSpecies.currentSpecies = SelectSpecies.currentSpecies-1;
    }
    public void ClickNextSpeciesBtn(){
        if (SelectSpecies.currentSpecies == 2 ){
            SelectSpecies.currentSpecies = 0;
        }
        else SelectSpecies.currentSpecies = SelectSpecies.currentSpecies+1;
    }
}
