using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public Slider slider;
    //public string nextscene;

    private string nextscene;
    private float time;
    private float end_time;
    private int newGame;
    private int continueGame;

    void Start() {
        newGame = PlayerPrefs.GetInt("new");
        continueGame = PlayerPrefs.GetInt("continue");
        StartCoroutine(LoadAsynSceneCoroutine());
        slider.value=0;
    }

    IEnumerator LoadAsynSceneCoroutine() {
        if (newGame == 1) {
            nextscene = "SelectScene";
        } else {
            nextscene = "HomeScene";
        }
        PlayerPrefs.DeleteAll();
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextscene);
        operation.allowSceneActivation = false;

        while (!operation.isDone) {
            time += 4f;

            slider.value = time/1000f;

            if (time>1800) {
                operation.allowSceneActivation=true;
            }
            yield return null;
        }
    }
}
