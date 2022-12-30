using System; /* for Serializable */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

[System.Serializable] 
public class Stat  
{
    public int coding_stat;
    public int know_stat;
    public int security_stat;
    public int sociality_stat;
    public int interest_stat;
    public int stress_stat;
    public int money_stat;
}

public class StatManager : MonoBehaviour
{
    public static StatManager Instance; 
    public Stat MyStat;

    string filePath = "Assets/Resources/Json/test_stat.json";

    
    void Awake()
    {
        if (Instance == null){
            Instance = this;
            Debug.Log("111");//If DontDestroyOnLoad가 없다면 계속 호출될거임. 
            //왜냐! 씬이동시마다 요 datamanger 인스턴스는 없어질테니까!
        }
        else if (Instance != this){
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);//씬이동시, 기존 씬에 있던 게임 오브젝트는 모두 파괴됨, DontDestroyOnLoad은 이를 막음!
        //==>> StatManager는 어쨌든 끝까지 살아있고, 다른 클래스 간에 데이터 공유 GOOD!
    }

    public void LoadData(){
        string jsonData = File.ReadAllText(filePath);//텍스트 그 자체를 불러옴
        MyStat = JsonConvert.DeserializeObject<Stat>(jsonData);//json형태로 파싱! , 구조 Stat는 위에서 정의해놨음
    }
    public void SaveData(){
        string classToJson = JsonConvert.SerializeObject(MyStat);//MyStat class를 json으로
        File.WriteAllText(filePath, classToJson);
    }}
