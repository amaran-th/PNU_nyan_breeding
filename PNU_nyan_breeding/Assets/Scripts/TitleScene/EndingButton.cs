using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButton : MonoBehaviour
{
    public static List<Dictionary<int, EndingDialogue>> normalEnding;
    
    void Awake() {
        ShareData.whichEnding[0] = true;
        ShareData.endingIndex = 0;  
    }

    public void OnClickEnddingButton(){
        SceneManager.LoadScene("EndingScene");
    }  
}
