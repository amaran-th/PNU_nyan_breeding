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
    
    //TODO NpcEvent Scene에서 활성화 시킨다
    bool[] _npcMail={false,false,false};
    public static bool[] npcMail {get{return Instance._npcMail;} set{Instance._npcMail=value;}}

    int _endIndex=0;
    public static int endingIndex  {get{return Instance._endIndex;} set{Instance._endIndex=value;}}
    
    bool[] _whichEnding = {false,false,false}; //normal,bad,hidden
    public static bool[] whichEnding {get{return Instance._whichEnding;} set{Instance._whichEnding=value;}}

    Dictionary<int,EndingDialogue> _ending = new Dictionary<int,EndingDialogue>();
    public static Dictionary<int,EndingDialogue> resEnding {get{return Instance._ending;} set{Instance._ending=value;}}

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
