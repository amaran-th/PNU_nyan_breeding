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
    private int id;
    private string name;
    private string img_path;

    public void Init(Activity activity){
        this.id=activity.id;
        this.name=activity.name;
        this.img_path=activity.img_path;
        text.text=name;
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
            CalenderController.scheduleImageList.Add(Resources.Load<Sprite>(img_path) as Sprite);
            //TimeTableManager.calender[CalenderController.scheduleCount].GetComponent<Image>().sprite=Resources.Load<Sprite>("test/oomoo1") as Sprite;
            CalenderController.scheduleCount=CalenderController.scheduleImageList.Count;
            Debug.Log(CalenderController.scheduleCount);
        }
    }
}
