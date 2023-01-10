using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   ////
using Newtonsoft.Json;  ////

public class PlayerInfo{
    public string name;
    public Species species;
}

public enum Species{
    Species1, Species2, Species3
}

public class PlayerInfoManager : MonoBehaviour
{
    public static PlayerInfoManager instance;
    public PlayerInfo playerInfo;
 
    //랜덤 이름을 저장할 리스트
    public static List<string> randomNameList=new List<string>();   ////
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this){
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()    ////
    {
        LoadRandomNameList();   
        Debug.Log(randomNameList.Count);    
    }   
    
    void Update()
    {
       // Debug.Log(playerInfo.species);
    }

    void LoadRandomNameList(){  ////
        var ta=Resources.Load<TextAsset>("Json/test_data");
        Debug.Log(ta);
        var json=ta.text;
        var arrData=JsonConvert.DeserializeObject<NameData[]>(json);
        foreach(var data in arrData)
        {
            randomNameList.Add(data.name);
        }
        
        
    }
}
