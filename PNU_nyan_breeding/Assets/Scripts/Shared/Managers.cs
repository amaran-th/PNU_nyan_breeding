using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers: MonoBehaviour
{
    static Managers s_instance;  
    static Managers Instance { get { Init(); return s_instance; } }

    DataManager _data = new DataManager();
    public static DataManager Data { get { return Instance._data; } }

    PlayerManager _player = new PlayerManager();
    public static PlayerManager Player { get { return Instance._player; } }

    void Start()
    {
        Init();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject obj = GameObject.Find("@Managers");
            if (obj == null)
            {
                obj = new GameObject { name = "@Managers" };
                obj.AddComponent<Managers>();
            }

            DontDestroyOnLoad(obj);
            s_instance = obj.GetComponent<Managers>();
            s_instance._data.Init();
            s_instance._player.Init();
        }		
	}
}
