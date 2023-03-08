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
    
    public void OnClickEndingButton(){
        private EndingCollection endingCollectionData = new EndingCollection();
        SceneManager.LoadScene("EndingScene");
    }  

    public void OnClickEndingCollectionButton(){
        endingCollectionData = Managers.Player.LoadJson<EndingCollection>(Application.persistentDataPath + $"/ending");
        Managers.Player.endingCollectionData = endingCollectionData;
        SceneManager.LoadScene("EndingCollectionScene");
    } 
}
