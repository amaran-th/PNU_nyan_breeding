using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public static Dictionary<int, NPC> npcData;   //DataManager를 통해 로드된 활동 데이터
    
    void Awake(){
        //Json 파일로부터 데이터 로드
        npcData = Managers.Data.npcData;    
    }
    void Start()
    {

        Debug.Log(npcData.Count);
    }

    void Update()
    {
        
    }
}
