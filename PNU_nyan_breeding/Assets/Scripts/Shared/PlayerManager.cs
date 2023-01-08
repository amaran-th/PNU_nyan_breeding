using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class PlayerManager: MonoBehaviour  
{
    private string folderPath ;

    public PlayerInfo playerInfoData = new PlayerInfo(); 
    private string playerInfoDataPath="player_info.json"; //이름, 대학, 종

    public void Init()
    {
        playerInfoData = LoadJson<PlayerInfo>(playerInfoDataPath);
        folderPath = Application.dataPath + "/Resources/Json/";
    }


    Loader LoadJson<Loader>(string filePath) 
    {
		string data = File.ReadAllText(folderPath + filePath);
        return JsonUtility.FromJson<Loader>(data);
	}

    public void SaveData() 
    {
        string json = JsonUtility.ToJson(playerInfoData);
        File.WriteAllText(folderPath + playerInfoDataPath, json);
    }
}
