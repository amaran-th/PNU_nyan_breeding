using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButton : MonoBehaviour
{
    public static List<Dictionary<int, EndingDialogue>> normalEnding;
    
    void Awake() {
        normalEnding = EndingManager.normalEnding;
        ShareData.EndingIndex = 0;  
        Temp();
    }

    void Temp() {
        ShareData.resEnding = normalEnding[0];
    }
    
    public void OnClickEnddingButton(){
        SceneManager.LoadScene("EndingScene");
    }  
}
