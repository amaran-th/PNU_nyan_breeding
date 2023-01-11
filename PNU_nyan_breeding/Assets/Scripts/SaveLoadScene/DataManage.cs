using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    public string name;
    public int catType;
}

public class DataManage : MonoBehaviour
{
    public static DataManage instance;

    public PlayerData nowPlayerData = new PlayerData();
    public string path;
    public int slotNumber;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;   
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/" + "save";
    }

/*
    // Start is called before the first frame update
    void Start()
    {
    
    }
*/

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayerData);
        File.WriteAllText(path + slotNumber.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + slotNumber.ToString());
        nowPlayerData = JsonUtility.FromJson<PlayerData>(data);
    }

/*
    // Update is called once per frame
    void Update()
    {
        
    }
*/
    public void DataClear()
    {
        slotNumber = -1;
        nowPlayerData = new PlayerData();
    }
}