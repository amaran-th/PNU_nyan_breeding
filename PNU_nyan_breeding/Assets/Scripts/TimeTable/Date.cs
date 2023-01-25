using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Date : MonoBehaviour
{
    public TMP_Text grade;
    public TMP_Text month;
    void Awake() {
        Debug.Log(TimeTableManager.grade);
        grade.text=TimeTableManager.grade+"학년";
        month.text=TimeTableManager.month+"월";
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
