using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowStat : MonoBehaviour
{
    public GameObject stat; // stat prefabs
    
    void Start()
    {
          for(int i=0;i<6;i++){//money stat제외
            
            var statItem=Instantiate(stat,transform); //자식 객체 생성
            statItem.name = "statObj";//자식객체 이름 설정
            statItem.transform.localPosition=new Vector3(0f,70f+ -i*30f, 0f); 

            Debug.Log(MonthlyResultManager.Diff[i]);
            if(MonthlyResultManager.Diff[i]>0){
                statItem.transform.Find("Origin").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i];
                statItem.transform.Find("Change").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i] + MonthlyResultManager.Diff[i];
            }
            else if (MonthlyResultManager.Diff[i]<0){
                statItem.transform.Find("Change").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i];
                statItem.transform.Find("Origin").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i] + MonthlyResultManager.Diff[i];

                statItem.transform.Find("Change").Find("Fill Area").Find("Fill").GetComponent<Image>().color  = new Color(0,0,255); //파란색

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
