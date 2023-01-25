using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{
    public int scheduleNo;
    
    public void OnClickSchedule(){
        if(scheduleNo<CalenderController.scheduleCount){
            TimeTableManager.selectedMoney-=CalenderController.scheduleList[scheduleNo].money_stat;
            CalenderController.scheduleList.RemoveAt(scheduleNo);
            CalenderController.scheduleCount=CalenderController.scheduleList.Count;
        }
    }
}
