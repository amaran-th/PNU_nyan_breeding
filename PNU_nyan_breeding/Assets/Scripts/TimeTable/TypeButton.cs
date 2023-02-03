using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeButton : MonoBehaviour
{   
    public int type;
    public Button button;
    private Vector3 originPos;
    private Vector3 selectedPos;

    public void Start(){
        button.GetComponent<Image>().color=new Color(0.7f,0.7f,0.7f,1f);
        originPos=button.transform.localPosition;
        selectedPos=originPos;
        selectedPos.x += 8f; 
    }
    public void Update(){
        //button.image.color=((int)TimeTableManager.currentType==type)?Color.yellow:Color.white;
        if((int)MemoListController.currentType==type){
            button.GetComponent<Image>().color=new Color(1f,1f,1f,1f);
            button.transform.localPosition=selectedPos;
        }else{
            button.GetComponent<Image>().color=new Color(0.7f,0.7f,0.7f,1f);
            button.transform.localPosition=originPos;
        }
    }
    public void OnClickTypeButton(){
        MemoListController.currentType=(ActivityType)type; //type 업데이트   
    }
}
