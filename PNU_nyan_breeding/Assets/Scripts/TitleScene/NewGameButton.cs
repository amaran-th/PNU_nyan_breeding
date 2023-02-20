using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClickNewGameButton()
    {
        PlayerPrefs.SetInt("new", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LoadingScene");
    }
}
