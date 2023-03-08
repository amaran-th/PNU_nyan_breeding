using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPlayerStat : MonoBehaviour
{
    public GameObject stat; // stat prefabs
    public TextMeshProUGUI statText; 
    
    //     CodingStat.value = HomeManager.playerStatData.coding_stat;
    void Start()
    {
        
          for(int i=0;i<7;i++){//money stat제외
            
            var statItem=Instantiate(stat,transform); //자식 객체 생성
            statItem.name = "statObj";//자식객체 이름 설정
 
            statItem.transform.localPosition=new Vector3(0f, 1f -i*70f , 0f); 
            statItem.transform.Find("Origin").GetComponent<Slider>().value = HomeManager.playerStat[i];

            statText.text += HomeManager.playerStat[i] + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
