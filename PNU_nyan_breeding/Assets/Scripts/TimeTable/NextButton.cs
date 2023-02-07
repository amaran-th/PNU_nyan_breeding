using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void NextScene() {
        ShareData.fixedScheduleList=CalenderController.scheduleList;
        SceneManager.LoadScene("MapScene");
    }
}
