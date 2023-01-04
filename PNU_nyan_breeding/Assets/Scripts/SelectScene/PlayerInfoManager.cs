using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo{
    public string name;
    public Species species;
}

public enum Species{
    Species1, Species2, Species3
}

public class PlayerInfoManager : MonoBehaviour
{
    public static PlayerInfoManager instance;
    public PlayerInfo playerInfo;
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this){
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(playerInfo.species);
    }
}
