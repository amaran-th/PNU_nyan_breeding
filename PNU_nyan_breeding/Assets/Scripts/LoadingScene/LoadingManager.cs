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
    private int newGame;
    private int continueGame;

    void Start() {
        newGame = PlayerPrefs.GetInt("new");
        continueGame = PlayerPrefs.GetInt("continue");
        StartCoroutine(LoadAsynSceneCoroutine());
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
            time += Time.time;

            slider.value = time/1000f;

            if (time>2000) {
                operation.allowSceneActivation=true;
            }
            yield return null;
        }
    }
}
