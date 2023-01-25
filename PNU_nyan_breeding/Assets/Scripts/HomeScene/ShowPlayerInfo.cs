using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPlayerInfo : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text University;
    public GameObject Cat;

    void Start()
    {
        
        Name.text = HomeManager.playerInfoData.name;
        University.text = HomeManager.playerInfoData.university;

        if(HomeManager.playerInfoData.species == 0)
            Cat.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cat/0103고등어스탠딩") as Sprite;
        else if(HomeManager.playerInfoData.species == 1)
            Cat.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cat/0103삼색이스탠딩") as Sprite;
        else if(HomeManager.playerInfoData.species == 2)
            Cat.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cat/0103치즈스탠딩") as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
