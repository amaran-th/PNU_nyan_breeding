using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCIcon : MonoBehaviour
{
    public int index;
    
    private NPC data;
    // Start is called before the first frame update
    void Start()
    {
        data=MapManager.npcData[index];
        GetComponent<Image>().sprite=Resources.Load<Sprite>(data.img_path) as Sprite;
        Debug.Log(data.img_path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickIcon(){
        MapManager.currentNpc=index;
        Debug.Log(MapManager.currentNpc);
    }
}
