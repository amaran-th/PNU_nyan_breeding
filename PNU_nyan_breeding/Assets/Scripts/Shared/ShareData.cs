using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareData : MonoBehaviour
{
    static ShareData s_instance;
    static ShareData Instance { get { Init(); return s_instance; } }
    
    public static List<Activity> fixedScheduleList=new List<Activity>();
    
    void Start()
    {
        Init();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject obj = GameObject.Find("@ShareData");
            if (obj == null)
            {
                obj = new GameObject { name = "@ShareData" };
                obj.AddComponent<ShareData>();
            }

            DontDestroyOnLoad(obj);
            s_instance = obj.GetComponent<ShareData>();
            
        }		
	}
}
