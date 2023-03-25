using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialMonthlyShowStat : MonoBehaviour
{
    public GameObject stat; // stat prefabs
    public TextMeshProUGUI statChange; //
    public TextMeshProUGUI statOrigin; 
    
    void Start()
    {
          for(int i=0;i<7;i++){//money stat제외
            
            var statItem=Instantiate(stat,transform); //자식 객체 생성
            statItem.name = "statObj";//자식객체 이름 설정
            statItem.transform.localScale = new Vector3(1.25f, 1.25f, 0f);
            statItem.transform.localPosition=new Vector3(0f, 1f -i*86f , 0f); 

            statItem.transform.Find("Origin").GetComponent<Slider>().value = 30;
            

            if(i==0){
                statItem.transform.Find("Change").GetComponent<Slider>().value = 50;
                statItem.transform.Find("Change").Find("Fill Area").Find("Fill").GetComponent<Image>().color  = new Color32(36,125,255,255);
                statOrigin.text += "50\n";
                statChange.text += "<color=#247DFF>+20</color>\n";
            
            }
            else if (i==1){
                statItem.transform.Find("Change").GetComponent<Slider>().value = 50;
      
                statOrigin.text += "30\n";
                statChange.text += "<color=#FF5033>-20</color>\n";
              
            }
            else {
                statOrigin.text += "10\n";
                statChange.text += "0\n";
            }
        
    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
