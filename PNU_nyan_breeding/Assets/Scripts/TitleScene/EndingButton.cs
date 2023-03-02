using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButton : MonoBehaviour
{
    private EndingCollection endingCollectionData = new EndingCollection();

    public void OnClickEndingButton(){
        SceneManager.LoadScene("EndingScene");
    }  

    public void OnClickEndingCollectionButton(){
        endingCollectionData = Managers.Player.LoadJson<EndingCollection>(Application.persistentDataPath + $"/ending");
        Managers.Player.endingCollectionData = endingCollectionData;
        SceneManager.LoadScene("EndingCollectionScene");
    } 
}
