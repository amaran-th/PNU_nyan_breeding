using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectCatSpecies : MonoBehaviour, IPointerClickHandler
{
    public Species species;
    // public Button m_Strite;
    // void Awake(){
    //      m_Strite = GetComponent<Button>(); 
    // }
    // void OnMouseDown() {
    //     //PlayerInfoManager.instance.playerInfo.species = species;
    //     Debug.Log("!11");
    // }

    public void OnPointerClick(PointerEventData pointerEventData){
        Debug.Log("abc");
    }
}
