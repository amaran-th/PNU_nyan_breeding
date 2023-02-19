using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialShowPlayerStat : MonoBehaviour
{
    public GameObject stat; // stat prefabs
    
    void Start()
    {
        
          for(int i=0;i<7;i++){//money stat제외
            
            var statItem=Instantiate(stat,transform); //자식 객체 생성
            statItem.name = "statObj";//자식객체 이름 설정
            statItem.transform.localPosition=new Vector3(50f, 200f + -i*68f, 0f); 

        
            statItem.transform.Find("Origin").GetComponent<Slider>().value = TutorialManager.playerStat[i];
        }
    }

   
}
