using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    Image loadingbar;
    // Start is called before the first frame update
    void Start()
    {
        loadingbar.fillAmount = 0;
        StartCoroutine("Load");
    }

    // Update is called once per frame
    void LoadScene(string scenename) {
        SceneManager.LoadScene("LoadingScene");
    }

    // 로딩
    IEnumerator LoadAsyncScene()
    {
        yield return null;
        
    }
}
