using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class PlayerManager: MonoBehaviour  
{
    private string folderPath;
    private string SavePath;

    public Player playerData = new Player(); // 부모? 클래스  Player 저장
    public PlayerInfo playerInfoData = new PlayerInfo(); // 부모? 클래스  Player 저장
    public PlayerStat playerStatData = new PlayerStat(); //이중 클래스 PlayerStat 저장

 
    public void Init() 
    {
       // SavePath = Application.persistentDataPath + "/player_info.json";

        // playerData = LoadJson<Player>(SavePath); // 부모클래스 json -> object가져옴
        // playerInfoData = playerData.playerInfo;
        // playerStatData = playerData.playerStat; // 부모클래스 ->0 이중 클래스 가져오기!!
    }


    // Loader LoadJson<Loader>(string filePath) 
    // {
   //    SaveData();

    //     string data = File.ReadAllText(filePath);
    //     return JsonUtility.FromJson<Loader>(data);
   // }

    // public void SaveData() 
    // {
    //     string json = JsonUtility.ToJson(playerData);
    //     File.WriteAllText(SavePath, json);
    // }
}