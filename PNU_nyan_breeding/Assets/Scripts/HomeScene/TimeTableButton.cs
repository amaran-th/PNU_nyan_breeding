using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTableButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClickTimeTableButton()
    {
        if(ShareData.isLotto){
            Debug.Log("확인하지 않은 로또 결과가 있습니다!");
            return;
        }
        SceneManager.LoadScene("TimeTableScene");
    }
}
