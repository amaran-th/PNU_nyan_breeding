using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareData : MonoBehaviour
{
    static ShareData s_instance;
    public static ShareData Instance { get { Init(); return s_instance; } }
    
    List<Activity> _schedule=new List<Activity>();
    public static List<Activity> fixedScheduleList {get{return Instance._schedule;} set{Instance._schedule=value;} }

    int _npcId=-1;
    public static int selectedNPCId {get{return Instance._npcId;} set{Instance._npcId=value;} }
    
    bool _lotto=false;
    public static bool isLotto {get{return Instance._lotto;} set{Instance._lotto=value;}}
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
