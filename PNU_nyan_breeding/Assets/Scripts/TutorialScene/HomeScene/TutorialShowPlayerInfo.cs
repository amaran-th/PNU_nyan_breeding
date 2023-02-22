using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialShowPlayerInfo : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Grade;
    public TMP_Text Month;
    public TMP_Text moneyStat;
    public GameObject Cat;
    

    void Start()
    {
        
        Name.text = TutorialController.playerInfoData.name;

        if(TutorialController.playerInfoData.species == 0)
            Cat.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cat/0103고등어스탠딩") as Sprite;
        else if(TutorialController.playerInfoData.species == 1)
            Cat.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cat/0103삼색이스탠딩") as Sprite;
        else if(TutorialController.playerInfoData.species == 2)
            Cat.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cat/0103치즈스탠딩") as Sprite;

        Grade.text = TutorialController.playerInfoData.grade.ToString();
        Month.text = TutorialController.playerInfoData.month.ToString();
        moneyStat.text =  TutorialController.playerInfoData.money_stat.ToString();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
