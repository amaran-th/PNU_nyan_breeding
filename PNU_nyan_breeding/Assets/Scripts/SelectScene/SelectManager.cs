using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   ////
using Newtonsoft.Json;  ////

public class SelectManager : MonoBehaviour
{

    public static Dictionary<int,CatSpecies> catSpeciesData; 
    public static Dictionary<int,RandomName> randomNameData;
    
     void Awake(){
        //Json 파일로부터 데이터 로드
        catSpeciesData = Managers.Data.catSpeciesDataList; 
        randomNameData = Managers.Data.randomNameDataList; 
    }
}