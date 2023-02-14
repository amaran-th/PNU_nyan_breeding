using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public Slider slider;
    public string nextscene;

    private float time;

    void Start() {
        StartCoroutine(LoadAsynSceneCoroutine());
    }

    IEnumerator LoadAsynSceneCoroutine() {

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextscene);
        operation.allowSceneActivation = false;

        while (!operation.isDone) {
            time += Time.time;

            slider.value = time/1000f;

            if (time>1500) {
                operation.allowSceneActivation=true;
            }
            yield return null;
        }
    }
}
