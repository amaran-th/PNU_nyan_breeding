using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   ////
using Newtonsoft.Json;  ////

public class SelectManager : MonoBehaviour
{

    public static Dictionary<int,CatSpecies> catSpeciesData;   //
    
     void Awake(){
        //Json 파일로부터 데이터 로드
        catSpeciesData = Managers.Data.catSpeciesDataList; 
    }
    


    // //랜덤 이름을 저장할 리스트
    // public static List<string> randomNameList=new List<string>();   ////

    // void LoadRandomNameList(){  ////
    //     var ta=Resources.Load<TextAsset>("Json/test_data");
    //     var json=ta.text;
    //     var arrData=JsonConvert.DeserializeObject<NameData[]>(json);
    //     foreach(var data in arrData)
    //     {
    //         randomNameList.Add(data.name);
    //     }
        
        
    // }
}
