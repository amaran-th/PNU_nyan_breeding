using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceModal : MonoBehaviour
{
    public TMP_Text modalText;
    void Start()
    {
        
    }

    void Update()
    {
        UpdateModalText();
    }

    void UpdateModalText(){
        if(MapManager.currentNpc>=0){
            modalText.text=MapManager.npcData[MapManager.currentNpc].name+"을(를) 만나러 갈까?";
        }
        
    }
}
