using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TestListItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IScrollHandler
{
    public ScrollRect scrollRect;
    public TMP_Text text;
    private Activity activity;

    public void Init(Activity activity){
        this.activity=activity;
        //this.id=activity.id;
        //this.name=activity.name;
        //this.img_path=activity.img_path;
        text.text=activity.name;
        scrollRect=transform.parent.parent.parent.GetComponent<ScrollRect>();
    }
    public void OnBeginDrag(PointerEventData e){
        scrollRect.OnBeginDrag(e);
    }
    public void OnDrag(PointerEventData e){
        scrollRect.OnDrag(e);
    }
    public void OnEndDrag(PointerEventData e){
        scrollRect.OnEndDrag(e);
    }
    public void OnScroll(PointerEventData e){
        scrollRect.OnScroll(e);
    }
     public void OnClickItem(){ //Activity Type에 따른 텍스트 업데이트
        //text.text=TypeButton.GetActivityType().ToString();
        //Debug.Log(img_path);
        if(CalenderController.scheduleCount<3){
            if(TimeTableManager.curMoney+TimeTableManager.selectedMoney+activity.money_stat<0){
                Debug.Log("돈이 부족하다!");
                return;
            }
            CalenderController.scheduleList.Add(activity);
            CalenderController.scheduleCount=CalenderController.scheduleList.Count;
            TimeTableManager.selectedMoney+=activity.money_stat;
            Debug.Log(CalenderController.scheduleCount);
        }
    }
}
