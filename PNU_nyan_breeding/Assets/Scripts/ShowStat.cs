using System; /* for Serializable */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;


[System.Serializable] 
public class ShowStat : MonoBehaviour
{
    public Slider coding_stat;
    public Slider know_stat;
    public Slider security_stat;
    public Slider sociality_stat;
    public Slider interest_stat;
    public Slider stress_stat;

    //씬이동
    public Button scence_button;

    void Start()
    {
        StatManager.Instance.LoadData(); //별다른 선언없이 StatManager바로 사용함!
        Stat MyStat = StatManager.Instance.MyStat;

        coding_stat.value =  MyStat.coding_stat; //slider에 적용
        know_stat.value =  MyStat.know_stat;
        security_stat.value =  MyStat.security_stat;
        sociality_stat.value =  MyStat.sociality_stat; 
        interest_stat.value =  MyStat.interest_stat;
        stress_stat.value =  MyStat.stress_stat;

        //씬이동
        scence_button.onClick.AddListener(NextScence);
    }

    //씬이동
    void NextScence()
    {
        SceneManager.LoadScene("TestData2");
    }
}
