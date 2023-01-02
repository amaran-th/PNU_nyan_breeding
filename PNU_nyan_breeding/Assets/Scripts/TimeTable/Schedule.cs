using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{
    public int scheduleNo;
    
    public void OnClickSchedule(){
        if(scheduleNo<CalenderController.scheduleCount){
            CalenderController.scheduleImageList.RemoveAt(scheduleNo);
            CalenderController.scheduleCount=CalenderController.scheduleImageList.Count;
        }
    }
}
