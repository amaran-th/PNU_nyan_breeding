using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IncreaseStatBtn : MonoBehaviour
{
    public Button increase_button;
    //씬이동
    public Button scence_button;

    Stat MyStat;

    void Start()
    {
        StatManager.Instance.LoadData();
        MyStat = StatManager.Instance.MyStat;

        increase_button.onClick.AddListener(IncreaseStat);
        //씬이동
        scence_button.onClick.AddListener(NextScence);
    }


    void IncreaseStat()
    {
        MyStat.stress_stat =  MyStat.stress_stat + 10;

        StatManager.Instance.SaveData(); 
        Debug.Log(MyStat.stress_stat);
    }
     //씬이동
    void NextScence()
    {
        SceneManager.LoadScene("TestData");
    }
}
